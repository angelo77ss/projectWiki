using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Wiki.Common.Util;

namespace Wiki.DataBase
{
    public sealed class DataSetMapper<T>
    {
        public U ConvertFromBackend<U>(DataTable dataTable) where U : ICollection<T>
        {
            U result = Activator.CreateInstance<U>();

            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(ConvertSingleFromBackend(row));
            }
            return result;
        }

        public T ConvertSingleFromBackend(DataRow row)
        {
            return (T)ConvertSingleFromBackend(typeof(T), row, String.Empty);
        }

        private object ConvertSingleFromBackend(Type type, DataRow row, string columnPrefix)
        {
            object result = null;
            try
            {
                result = Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Type: {0}.", type.FullName), ex);
            }

            foreach (var property in type.GetProperties())
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(MappingSettingsAttribute)) as MappingSettingsAttribute;
                if (attribute != null)
                {
                    string columnName = ((!String.IsNullOrEmpty(attribute.ColumName)) ? (attribute.ColumName) : (columnPrefix + property.Name));
                    if (attribute.Type == MappingSettingsAttribute.MappingType.Simple)
                    {
                        if (row.Table.Columns.Contains(columnName))
                        {
                            try
                            {
                                SetObjectValue(row, result, property, columnName);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Error mapeando columna: '" + columnName + "'" + Environment.NewLine + ex.ToString(), ex);
                            }
                        }
                        else
                        {
                            if (attribute.Required)
                            {
                                throw new InvalidOperationException(String.Format("Property: {1}. Type: {0}.", property.PropertyType.FullName, property.Name));
                            }
                        }
                    }
                    else
                    {
                        var innerProperty = property.PropertyType.GetProperties();
                        if (innerProperty.Length > 0)
                        {
                            property.SetValue(result, ConvertSingleFromBackend(property.PropertyType, row, columnPrefix + property.Name + "_"), null);
                        }
                        else
                        {
                            if (attribute.Required)
                            {
                                throw new InvalidOperationException(String.Format("Property: {1}. Type: {0}.", property.PropertyType.FullName, property.Name));
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static void SetObjectValue(DataRow row, object result, System.Reflection.PropertyInfo property, string columnName)
        {
            try
            {
                property.SetValue(result, ((row[columnName] is DBNull) ? (null) : (row[columnName])), null);
            }
            catch (Exception)
            {
                if ((row[columnName] is DBNull))
                {
                    property.SetValue(result, null, null);
                }
                else
                {
                    if (property.PropertyType.GetGenericArguments() != null && property.PropertyType.GetGenericArguments().Length > 0 && property.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        Type genericType = property.PropertyType.GetGenericArguments()[0];

                        if (property.PropertyType.GetGenericArguments().Length > 0)
                        {
                            Type nullableType = property.PropertyType.GetGenericArguments()[0];
                            if (nullableType.BaseType == typeof(Enum))
                            {
                                object o = Enum.Parse(nullableType, (row[columnName]).ToString());
                                property.SetValue(result, o, null);
                            }
                            else
                            {
                                property.SetValue(result, Convert.ChangeType(row[columnName], genericType), null);
                            }
                        }
                        else
                        {
                            property.SetValue(result, Convert.ChangeType(row[columnName], genericType), null);
                        }
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        property.SetValue(result, Enum.Parse(property.PropertyType, row[columnName].ToString()), null);
                    }
                    else
                    {
                        property.SetValue(result, Convert.ChangeType(row[columnName], property.PropertyType), null);
                    }
                }
            }
        }
    }
}
