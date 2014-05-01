using System;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;
using Wiki.Common.Exceptions;

namespace Wiki.DataBase
{
    public class SQLServerHelper
    {
        private int DEFAULT_TIMEOUT
        {
            get
            {
                return 600;
            }
        }
        private string _connectionString;

        /// <description> 
        /// Constructor 
        /// </description> 
        /// <param name="connectionString">Connection string value</param> 
        /// <raiseErrors></raiseErrors> 
        public SQLServerHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <description> 
        /// Create an SQL connection 
        /// </description> 
        /// <returns>A SQL connection</returns> 
        /// <raiseErrors></raiseErrors> 
        private SqlConnection CreateConnection()
        {
            SqlConnection sqlConnection;

            try
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = _connectionString;

                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error creating connexion", ex);
            }
            return sqlConnection;
        }

        /// <description> 
        /// Gets a data set from an stored procedure 
        /// </description> 
        /// <param name="storedProcedureName">Store procedure name</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public DataSet GetDataSet(string storedProcedureName)
        {
            return GetDataSet(storedProcedureName, null);
        }

        /// <description> 
        /// Gets a data set from an stored procedure 
        /// </description> 
        /// <param name="storedProcedureName">Store procedure name</param> 
        /// <param name="schema">Data set schema</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public DataSet GetDataSet(string storedProcedureName, ref DataSet schema)
        {
            return GetDataSet(storedProcedureName, ref schema, null);
        }

        /// <description> 
        /// Gets a data set from an stored procedure 
        /// </description> 
        /// <param name="storedProcedureName">Store procedure name</param> 
        /// <param name="parameters">Procedure parameters</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public DataSet GetDataSet(string storedProcedureName, params DataAccessParameter[] parameters)
        {
            var dataSet = new DataSet();
            return GetDataSet(storedProcedureName, ref dataSet, parameters);
        }

        /// <description> 
        /// Gets a data set from an stored procedure 
        /// </description> 
        /// <param name="storedProcedureName">Store procedure name</param> 
        /// <param name="schema">Data set schema</param> 
        /// <param name="parameters">Procedure parameters</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public DataSet GetDataSet(string storedProcedureName, ref DataSet schema, params DataAccessParameter[] parameters)
        {
            var result = ((schema == null) ? (new DataSet()) : (schema));
            SqlCommand sqlCommand = null;
            SqlConnection sqlConnection = null;

            try
            {

                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = storedProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = DEFAULT_TIMEOUT;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        AddParameter(sqlCommand, parameter);
                    }
                }

                var sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Latter binding
                sqlConnection = CreateConnection();
                sqlCommand.Connection = sqlConnection;

                sqlDataAdapter.Fill(result);

                if (parameters != null)
                {
                    foreach (var parameter in (from param in parameters
                                               where (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                                               select param))
                    {
                        parameter.Value = sqlCommand.Parameters[parameter.Name].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error running query", ex);
            }
            finally
            {
                if ((sqlCommand != null))
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if ((sqlConnection != null))
                {
                    sqlConnection.Close();
                    sqlConnection = null;
                }
            }
            return result;
        }

        /// <description> 
        /// Gets a data table from an stored procedure 
        /// </description> 
        /// <param name="storedProcedureName">The stored procedure name</param> 
        /// <returns>A data table</returns> 
        /// <raiseErrors></raiseErrors> 
        public DataTable GetDataTable(string storedProcedureName)
        {
            var dataTable = new DataTable();
            return GetDataTable(ref dataTable, storedProcedureName);
        }

        /// <description> 
        /// Gets a data table from an stored procedure 
        /// </description> 
        /// <param name="dataTable">The data table object</param> 
        /// <param name="storedProcedureName">The stored procedure name</param> 
        /// <returns>A data table</returns> 
        /// <raiseErrors></raiseErrors> 
        public DataTable GetDataTable(ref DataTable dataTable, string storedProcedureName)
        {
            return GetDataTable(ref dataTable, storedProcedureName, null);
        }

        /// <description> 
        /// Gets a data table from an stored procedure 
        /// </description> 
        /// <param name="dataTable">The data table object</param> 
        /// <param name="storedProcedureName">The stored procedure name</param> 
        /// <param name="parameters">The parameters colection</param> 
        /// <returns>A data table</returns> 
        /// <raiseErrors></raiseErrors> 
        public DataTable GetDataTable(string storedProcedureName, params DataAccessParameter[] parameters)
        {
            var dataTable = new DataTable();
            return GetDataTable(ref dataTable, storedProcedureName, parameters);
        }

        /// <description> 
        /// Gets a data table from an stored procedure 
        /// </description> 
        /// <param name="dataTable">The data table object</param> 
        /// <param name="storedProcedureName">The stored procedure name</param> 
        /// <param name="parameters">The parameters colection</param> 
        /// <returns>A data table</returns> 
        /// <raiseErrors></raiseErrors> 
        public DataTable GetDataTable(ref DataTable dataTable, string storedProcedureName, params DataAccessParameter[] parameters)
        {
            var result = ((dataTable == null) ? (new DataTable()) : (dataTable));
            SqlCommand sqlCommand = null;
            SqlConnection sqlConnection = null;

            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = storedProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                if ((parameters != null))
                {
                    foreach (var parameter in parameters)
                    {
                        AddParameter(sqlCommand, parameter);
                    }
                }

                var sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Latter binding
                sqlConnection = CreateConnection();
                sqlCommand.Connection = sqlConnection;

                sqlDataAdapter.Fill(result);

                if (parameters != null)
                {
                    foreach (var parameter in (from param in parameters
                                               where (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                                               select param))
                    {
                        parameter.Value = sqlCommand.Parameters[parameter.Name].Value;
                    }
                }
            }

            catch (Exception ex)
            {
                throw new DataAccessException("Error running query", ex);
            }
            finally
            {
                if ((sqlCommand != null))
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if ((sqlConnection != null))
                {
                    sqlConnection.Close();
                    sqlConnection = null;
                }
            }

            return result;
        }

        /// <description> 
        /// Executes an stored procedures 
        /// </description> 
        /// <param name="storedProcedureName">The store procedure name</param> 
        /// <returns>The rows affected count</returns> 
        /// <raiseErrors> 
        /// CPBillDataAccessOperationalException, 
        /// CPBillDataAccessDuplicateElementException, 
        /// CPBillDataAccessException 
        /// </raiseErrors>  
        public int ExecuteStoredProcedure(string storedProcedureName)
        {
            return ExecuteStoredProcedure(storedProcedureName, Int32.MinValue);
        }

        /// <description> 
        /// Executes an stored procedures 
        /// </description> 
        /// <param name="storedProcedureName">The store procedure name</param> 
        /// <param name="parameters">Parameters collection</param> 
        /// <returns>The rows affected count</returns> 
        /// <raiseErrors> 
        /// CPBillDataAccessOperationalException, 
        /// CPBillDataAccessDuplicateElementException, 
        /// CPBillDataAccessException 
        /// </raiseErrors>  
        public int ExecuteStoredProcedure(string storedProcedureName, params DataAccessParameter[] parameters)
        {
            return ExecuteStoredProcedure(storedProcedureName, Int32.MinValue, parameters);
        }

        /// <description> 
        /// Executes an stored procedures 
        /// </description> 
        /// <param name="storedProcedureName">The store procedure name</param> 
        /// <param name="timeout">Timeout</param> 
        /// <returns>The rows affected count</returns> 
        /// <raiseErrors> 
        /// CPBillDataAccessOperationalException, 
        /// CPBillDataAccessDuplicateElementException, 
        /// CPBillDataAccessException 
        /// </raiseErrors> 
        public int ExecuteStoredProcedure(string storedProcedureName, int timeout)
        {
            return ExecuteStoredProcedure(storedProcedureName, timeout, null);
        }

        /// <description> 
        /// Executes an stored procedures 
        /// </description> 
        /// <param name="storedProcedureName">The store procedure name</param> 
        /// <param name="timeout">Timeout</param> 
        /// <param name="parameters">Parameters collection</param> 
        /// <returns>The rows affected count</returns> 
        /// <raiseErrors> 
        /// CPBillDataAccessOperationalException, 
        /// CPBillDataAccessDuplicateElementException, 
        /// CPBillDataAccessException 
        /// </raiseErrors> 
        public int ExecuteStoredProcedure(string storedProcedureName, int timeout, params DataAccessParameter[] parameters)
        {
            var result = Int32.MinValue;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = storedProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (timeout != Int32.MinValue)
                {
                    sqlCommand.CommandTimeout = timeout;
                }
                else
                {
                    sqlCommand.CommandTimeout = DEFAULT_TIMEOUT;
                }

                if ((parameters != null))
                {
                    foreach (DataAccessParameter objParameter in parameters)
                    {
                        AddParameter(sqlCommand, objParameter);
                    }
                }

                var returnValueParameter = sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValueParameter.Direction = ParameterDirection.ReturnValue;

                // Later binding
                sqlConnection = CreateConnection();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.ExecuteNonQuery();

                if (parameters != null)
                {
                    foreach (var parameter in (from param in parameters
                                               where (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                                               select param))
                    {
                        parameter.Value = sqlCommand.Parameters[parameter.Name].Value;
                    }
                }

                result = (int)sqlCommand.Parameters["@ReturnValue"].Value;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error running query", ex);
            }
            finally
            {
                if ((sqlCommand != null))
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if ((sqlConnection != null))
                {
                    sqlConnection.Close();
                    sqlConnection = null;
                }
            }
            return result;
        }

        /// <description> 
        /// Adds a new parameter to the command's parameter collection 
        /// </description> 
        /// <param name="objSqlCommand">The SQL command</param> 
        /// <param name="objParameter">The data access parameter</param> 
        /// <returns>A SQL parameter</returns> 
        /// <raiseErrors></raiseErrors> 
        private SqlParameter AddParameter(SqlCommand sqlCommand, DataAccessParameter parameter)
        {
            SqlParameter result;

            if ((parameter.Value == null))
            {
                // Must have a type 
                result = new SqlParameter();
                result.ParameterName = parameter.Name;
                if (parameter.Type.Equals(typeof(String)) && !parameter.Size.HasValue)
                {
                    result.DbType = DbType.AnsiString;
                    result.Size = 8000;
                }
                else
                {
                    result.DbType = GetDbType(parameter.Type);
                    if (parameter.Size > Int32.MinValue)
                    {
                        result.Size = parameter.Size.Value;
                    }
                }
                result.Value = null;

                sqlCommand.Parameters.Add(result);
            }
            else
            {
                // Type is inferred from value 
                result = sqlCommand.Parameters.AddWithValue(parameter.Name.ToString(), parameter.Value);
            }

            result.Direction = parameter.Direction;

            return result;
        }

        /// <description> 
        /// Gets a DbType from a system type 
        /// </description> 
        /// <param name="objType">The system object type</param> 
        /// <returns>The database type</returns> 
        /// <raiseErrors>CPBillDataAccessException</raiseErrors>  
        private DbType GetDbType(Type type)
        {
            var typeConverter = TypeDescriptor.GetConverter(typeof(DbType));
            DbType result;
            // Try conversion 
            try
            {
                result = (DbType)typeConverter.ConvertFrom(type.Name);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error running query", ex);
            }

            return result;
        }

        /// <description> 
        /// Executes an stored procedure and returns its scalar result 
        /// </description> 
        /// <param name="storedProcedureName">The name of the stored procedure to be executed</param> 
        /// <returns>The first Column/Field corresponding value</returns> 
        /// <raiseErrors> 
        /// CPBillDataAccessOperationalException, 
        /// CPBillDataAccessDuplicateElementException, 
        /// CPBillDataAccessException 
        /// </raiseErrors> 
        public decimal ExecuteScalar(string storedProcedureName)
        {
            return ExecuteScalar(storedProcedureName, null);
        }

        /// <description> 
        /// Executes an stored procedure and returns its scalar result 
        /// </description> 
        /// <param name="storedProcedureName">The name of the stored procedure to be executed</param> 
        /// <param name="parameters">Parameter collection</param> 
        /// <returns>The first Column/Field corresponding value</returns> 
        /// <raiseErrors> 
        /// CPBillDataAccessOperationalException, 
        /// CPBillDataAccessDuplicateElementException, 
        /// CPBillDataAccessException 
        /// </raiseErrors> 
        public decimal ExecuteScalar(string storedProcedureName, params DataAccessParameter[] parameters)
        {
            var result = decimal.MinValue;

            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = storedProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                if ((parameters != null))
                {
                    foreach (var parameter in parameters)
                    {
                        AddParameter(sqlCommand, parameter);
                    }
                }

                sqlConnection = CreateConnection();
                sqlCommand.Connection = sqlConnection;

                result = (decimal)sqlCommand.ExecuteScalar();

                if (parameters != null)
                {
                    foreach (var parameter in (from param in parameters
                                               where (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                                               select param))
                    {
                        parameter.Value = sqlCommand.Parameters[parameter.Name].Value;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error running query", ex);
            }
            finally
            {
                if ((sqlCommand != null))
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if ((sqlConnection != null))
                {
                    sqlConnection.Close();
                    sqlConnection = null;
                }
            }
            return result;
        }

        /// <description> 
        /// Executes a SQL statement 
        /// </description> 
        /// <param name="sqlQuery">The SQL statment to be executed</param> 
        /// <param name="timeout">Timeout prior to throw an exception</param> 
        /// <returns>The value returned explicitily in the SQL statement</returns> 
        /// <raiseErrors>CPBillDataAccessException</raiseErrors> 
        public DataSet ExecuteSQL(string sqlQuery, int timeout)
        {
            DataSet result = null;

            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandTimeout = timeout;

                var dadObjDataAdapter = new SqlDataAdapter(sqlCommand);
                result = new DataSet();

                sqlConnection = CreateConnection();
                sqlCommand.Connection = sqlConnection;

                dadObjDataAdapter.Fill(result);
            }

            catch (Exception ex)
            {
                throw new DataAccessException("Error running query", ex);
            }
            finally
            {
                if ((sqlCommand != null))
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if ((sqlConnection != null))
                {
                    sqlConnection.Close();
                    sqlConnection = null;
                }
            }
            return result;
        }

        /// <description> 
        /// Gets a data Reader from an stored procedure 
        /// </description> 
        /// <param name="storedProcedureName">Store procedure name</param> 
        /// <param name="timeout">Timeout</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public SqlDataReader GetDataReader(string storedProcedureName, int timeout)
        {
            return GetDataReader(storedProcedureName, timeout, null);
        }

        /// <description> 
        /// Gets a data Reader from an stored procedure 
        /// </description> 
        /// <param name="storedProcedureName">Store procedure name</param> 
        /// <param name="timeout">Timeout</param> 
        /// <param name="parameters">Procedure parameters</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public SqlDataReader GetDataReader(string storedProcedureName, int timeOut, params DataAccessParameter[] parameters)
        {
            SqlDataReader result = null;

            var returnValue = Int32.MinValue;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = storedProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = timeOut;

                if (parameters != null)
                {
                    foreach (DataAccessParameter objParameter in parameters)
                    {
                        AddParameter(sqlCommand, objParameter);
                    }
                }

                var returnValueParameter = sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValueParameter.Direction = ParameterDirection.ReturnValue;

                var sqlConnection = CreateConnection();
                sqlCommand.Connection = sqlConnection;

                result = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                returnValue = (int)sqlCommand.Parameters["@ReturnValue"].Value;

                if (parameters != null)
                {
                    foreach (var parameter in (from param in parameters
                                               where (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                                               select param))
                    {
                        parameter.Value = sqlCommand.Parameters[parameter.Name].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error running query", ex);
            }
            finally
            {
                if ((sqlCommand != null))
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }
            //Connection is closed when datareader is closed 

            if ((returnValue < 0))
            {
                result = null;
            }
            return result;
        }
    }
}