using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using Wiki.Common.Util;

namespace Wiki.DataBase
{
    public class WikiDBAdapter
    {
        private const int DEFAULT_TIMEOUT = 600;

        /// <description> 
        /// Instantiates the helper 
        /// </description> 
        /// <returns>A SQLServerHelper object</returns> 
        /// <raiseErrors></raiseErrors> 
        private static SQLServerHelper CreateHelper()
        {
            return new SQLServerHelper(ConfigurationManager.ConnectionStrings["DBServer"].ConnectionString);
        }

        /// <description> 
        /// Instancia un SQLServerHelper con una BD en particular
        /// </description> 
        /// <returns>A SQLServerHelper object</returns> 
        /// <raiseErrors></raiseErrors> 
        private static SQLServerHelper CreateHelper(Enumerations.DBServerType serverType)
        {
            return new SQLServerHelper(ConfigurationManager.ConnectionStrings[serverType.ToString()].ConnectionString);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a dataset 
        /// </description> 
        /// <param name="storedProcedureName">Store procedure name</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors>  
        public static DataSet GetDataSet(string storedProcedureName)
        {
            return CreateHelper().GetDataSet(storedProcedureName);
        }

        public static DataSet GetDataSet(Enumerations.DBServerType serverType, string storedProcedureName)
        {
            return CreateHelper(serverType).GetDataSet(storedProcedureName);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a dataset 
        /// </description> 
        /// <param name="storedProcedureName">Store procedure name</param> 
        /// <param name="parameters">Procedure parameters</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors>  
        public static DataSet GetDataSet(string storedProcedureName, params DataAccessParameter[] parameters)
        {
            var dataSet = new DataSet();
            return CreateHelper().GetDataSet(storedProcedureName, ref dataSet, parameters);
        }

        public static DataSet GetDataSet(Enumerations.DBServerType serverType, string storedProcedureName, params DataAccessParameter[] parameters)
        {
            var dataSet = new DataSet();
            return CreateHelper(serverType).GetDataSet(storedProcedureName, ref dataSet, parameters);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a datatable 
        /// </description> 
        /// <param name="storedProcedureName">The stored procedure name</param> 
        /// <returns>A data table</returns> 
        /// <raiseErrors></raiseErrors> 
        public static DataTable GetDataTable(string storedProcedureName)
        {
            return CreateHelper().GetDataTable(storedProcedureName);
        }

        public static DataTable GetDataTable(Enumerations.DBServerType serverType, string storedProcedureName)
        {
            return CreateHelper(serverType).GetDataTable(storedProcedureName);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a datatable 
        /// </description> 
        /// <param name="storedProcedureName">The stored procedure name</param> 
        /// <param name="parameters">The parameters colection</param> 
        /// <returns>A data table</returns> 
        /// <raiseErrors></raiseErrors> 
        public static DataTable GetDataTable(string storedProcedureName, params DataAccessParameter[] parameters)
        {
            return CreateHelper().GetDataTable(storedProcedureName, parameters);
        }

        public static DataTable GetDataTable(Enumerations.DBServerType serverType, string storedProcedureName, params DataAccessParameter[] parameters)
        {
            return CreateHelper(serverType).GetDataTable(storedProcedureName, parameters);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a datatable 
        /// </description> 
        /// <param name="storedProcedureName">The stored procedure name</param> 
        /// <param name="dataTable">The data table instance </param> 
        /// <param name="parameters">The parameters colection</param> 
        /// <returns>A data table</returns> 
        /// <raiseErrors></raiseErrors> 
        public static DataTable GetDataTable(ref DataTable dataTable, string storedProcedureName)
        {
            return CreateHelper().GetDataTable(ref dataTable, storedProcedureName);
        }

        public static DataTable GetDataTable(Enumerations.DBServerType serverType, ref DataTable dataTable, string storedProcedureName)
        {
            return CreateHelper(serverType).GetDataTable(ref dataTable, storedProcedureName);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a datatable 
        /// </description> 
        /// <param name="storedProcedureName">The stored procedure name</param> 
        /// <param name="dataTable">The data table instance </param> 
        /// <param name="parameters">The parameters colection</param> 
        /// <returns>A data table</returns> 
        /// <raiseErrors></raiseErrors> 
        public static DataTable GetDataTable(ref DataTable dataTable, string storedProcedureName, params DataAccessParameter[] parameters)
        {
            return CreateHelper().GetDataTable(ref dataTable, storedProcedureName, parameters);
        }

        public static DataTable GetDataTable(Enumerations.DBServerType serverType, ref DataTable dataTable, string storedProcedureName, params DataAccessParameter[] parameters)
        {
            return CreateHelper(serverType).GetDataTable(ref dataTable, storedProcedureName, parameters);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result 
        /// </description> 
        /// <param name="storedProcedureName">The store procedure name</param> 
        /// <returns>The rows affected count</returns> 
        /// <raiseErrors></raiseErrors> 
        public static int ExecuteStoredProcedure(string storedProcedureName)
        {
            return CreateHelper().ExecuteStoredProcedure(storedProcedureName);
        }

        public static int ExecuteStoredProcedure(Enumerations.DBServerType serverType, string storedProcedureName)
        {
            return CreateHelper(serverType).ExecuteStoredProcedure(storedProcedureName);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result 
        /// </description> 
        /// <param name="storedProcedureName">The store procedure name</param> 
        /// <param name="parameters">Parameter collection to be passed to the stored procedure</param> 
        /// <returns>The rows affected count</returns> 
        /// <raiseErrors></raiseErrors> 
        public static int ExecuteStoredProcedure(string storedProcedureName, params DataAccessParameter[] parameters)
        {
            return CreateHelper().ExecuteStoredProcedure(storedProcedureName, parameters);
        }

        public static int ExecuteStoredProcedure(Enumerations.DBServerType serverType, string storedProcedureName, params DataAccessParameter[] parameters)
        {
            return CreateHelper(serverType).ExecuteStoredProcedure(storedProcedureName, parameters);
        }

        /// <description> 
        /// Executes an stored procedure and returns its scalar result 
        /// </description> 
        /// <param name="tStoredProcedureName">The name of the stored procedure to be executed</param> 
        /// <returns>The first Column/Field corresponding integer value</returns> 
        /// <raiseErrors></raiseErrors> 
        public static decimal ExecuteScalar(string tStoredProcedureName)
        {
            return ExecuteScalar(tStoredProcedureName, null);
        }

        public static decimal ExecuteScalar(Enumerations.DBServerType serverType, string tStoredProcedureName)
        {
            return ExecuteScalar(serverType, tStoredProcedureName, null);
        }

        /// <description> 
        /// Executes an stored procedure and returns its scalar result 
        /// </description> 
        /// <param name="tStoredProcedureName">The name of the stored procedure to be executed</param> 
        /// <param name="parameters">Parameter collection to be passed to the stored procedure</param> 
        /// <returns>The first Column/Field corresponding integer value</returns> 
        /// <raiseErrors></raiseErrors> 
        public static decimal ExecuteScalar(string tStoredProcedureName, params DataAccessParameter[] parameters)
        {
            SQLServerHelper objSQLHelper = default(SQLServerHelper);
            objSQLHelper = CreateHelper();

            return objSQLHelper.ExecuteScalar(tStoredProcedureName, parameters);
        }

        public static decimal ExecuteScalar(Enumerations.DBServerType serverType, string tStoredProcedureName, params DataAccessParameter[] parameters)
        {
            SQLServerHelper objSQLHelper = default(SQLServerHelper);
            objSQLHelper = CreateHelper(serverType);

            return objSQLHelper.ExecuteScalar(tStoredProcedureName, parameters);
        }

        /// <description> 
        /// Executes a SQL statement 
        /// </description> 
        /// <param name="tSqlStatment">A SQL statment</param> 
        /// <param name="iTimeout">Timeout prior to throw an exception</param> 
        /// <returns>The data set with the value returned explicitily in the SQL statement</returns> 
        /// <raiseErrors>CPBillDataAccessException</raiseErrors> 

        public static DataSet ExecuteSQL(string tSqlStatment, int iTimeout)
        {
            SQLServerHelper objSQLHelper = default(SQLServerHelper);
            objSQLHelper = CreateHelper();

            return objSQLHelper.ExecuteSQL(tSqlStatment, iTimeout);
        }

        public static DataSet ExecuteSQL(Enumerations.DBServerType serverType, string tSqlStatment, int iTimeout)
        {
            SQLServerHelper objSQLHelper = default(SQLServerHelper);
            objSQLHelper = CreateHelper(serverType);

            return objSQLHelper.ExecuteSQL(tSqlStatment, iTimeout);
        }

        /// <description> 
        /// Gets Transaction Scope 
        /// </description> 
        /// <returns>The transaction scoupe</returns> 
        /// <raiseErrors></raiseErrors> 

        public static TransactionScope CreateTransactionScope()
        {
            TransactionScope objTransactionScope = default(TransactionScope);
            TransactionOptions objTransactionOptions = new TransactionOptions();
            objTransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            objTransactionScope = new TransactionScope();
            //Return New TransactionScope(TransactionScopeOption.Required, objTransactionOptions) 
            return objTransactionScope;
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a datareader 
        /// </description> 
        /// <param name="tStoredProcedureName">Store procedure name</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public static SqlDataReader GetDataReader(string tStoredProcedureName)
        {
            return GetDataReader(tStoredProcedureName, null);
        }

        public static SqlDataReader GetDataReader(Enumerations.DBServerType serverType, string tStoredProcedureName)
        {
            return GetDataReader(serverType, tStoredProcedureName, null);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a datareader 
        /// </description> 
        /// <param name="tStoredProcedureName">Store procedure name</param> 
        /// <param name="parameters">Procedure parameters</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public static SqlDataReader GetDataReader(string tStoredProcedureName, params DataAccessParameter[] parameters)
        {
            SQLServerHelper objSQLHelper = default(SQLServerHelper);
            objSQLHelper = CreateHelper();

            return objSQLHelper.GetDataReader(tStoredProcedureName, DEFAULT_TIMEOUT, parameters);
        }

        public static SqlDataReader GetDataReader(Enumerations.DBServerType serverType, string tStoredProcedureName, params DataAccessParameter[] parameters)
        {
            SQLServerHelper objSQLHelper = default(SQLServerHelper);
            objSQLHelper = CreateHelper(serverType);

            return objSQLHelper.GetDataReader(tStoredProcedureName, DEFAULT_TIMEOUT, parameters);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a datareader 
        /// </description> 
        /// <param name="tStoredProcedureName">Store procedure name</param> 
        /// <param name="colParameters">Procedure parameters</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public static SqlDataReader GetDataReader(string tStoredProcedureName, List<DataAccessParameter> colParameters, int iTimeout)
        {
            return GetDataReader(tStoredProcedureName, iTimeout, null);
        }

        public static SqlDataReader GetDataReader(Enumerations.DBServerType serverType, string tStoredProcedureName, List<DataAccessParameter> colParameters, int iTimeout)
        {
            return GetDataReader(serverType, tStoredProcedureName, iTimeout, null);
        }

        /// <description> 
        /// Executes an stored procedure and returns its result in a datareader 
        /// </description> 
        /// <param name="tStoredProcedureName">Store procedure name</param> 
        /// <param name="parameters">Procedure parameters</param> 
        /// <returns>A data set</returns> 
        /// <raiseErrors></raiseErrors> 
        public static SqlDataReader GetDataReader(string tStoredProcedureName, int iTimeout, params DataAccessParameter[] parameters)
        {
            SQLServerHelper objSQLHelper = default(SQLServerHelper);
            objSQLHelper = CreateHelper();

            return objSQLHelper.GetDataReader(tStoredProcedureName, iTimeout, parameters);
        }

        public static SqlDataReader GetDataReader(Enumerations.DBServerType serverType, string tStoredProcedureName, int iTimeout, params DataAccessParameter[] parameters)
        {
            SQLServerHelper objSQLHelper = default(SQLServerHelper);
            objSQLHelper = CreateHelper(serverType);

            return objSQLHelper.GetDataReader(tStoredProcedureName, iTimeout, parameters);
        }

    }
}