using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DNTv2
{
    public sealed class Utils
    {
        public static bool ColumnExists(SqlDataReader dataReader, string columnName)
        {
            for (Int32 iCol = 0; iCol < dataReader.FieldCount; iCol++)
                if (columnName.ToUpper().Equals(dataReader.GetName(iCol).ToUpper()))
                    return true;
            return false;
        }

        public static object GetValue(SqlDataReader dataReader, string key)
        {
            if (!dataReader[key].GetType().Equals(typeof(DBNull)))
                return dataReader[key];
            return null;
        }

        public static object GetValue(DataRow dataRow, string key)
        {
            if (!dataRow[key].GetType().Equals(typeof(DBNull)))
                return dataRow[key];
            return null;
        }

        public static object Populate(object o, DataRow dataRow)
        {
            foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
                Populate(o, dataRow, propertyInfo);
            return o;
        }

        public static object Populate(object o, SqlDataReader dataReader)
        {
            foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
                Populate(o, dataReader, propertyInfo);
            return o;
        }

        public static object Populate(object o, DataRow dataRow, string property)
        {
            PropertyInfo propertyInfo = o.GetType().GetProperty(property);
            if (null == propertyInfo)
                throw new ArgumentException();
            Populate(o, dataRow, propertyInfo);
            return o;
        }

        private static object Populate(object o, DataRow dataRow, PropertyInfo propertyInfo)
        {
            if (ColumnExists(dataRow, propertyInfo.Name))
            {
                object value = GetValue(dataRow, propertyInfo.Name);
                MethodInfo setMethod = propertyInfo.GetSetMethod();
                if (null != setMethod)
                {
                    if (typeof(bool).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        bool b = null != value && (true.Equals(value) || 1.Equals(value) || "1".Equals(value.ToString()));
                        setMethod.Invoke(o, new object[] { b });
                    }                    
                    else 
                        setMethod.Invoke(o, new object[] { value });
                }
            }
            return o;
        }

        private static object Populate(object o, SqlDataReader dataReader, PropertyInfo propertyInfo)
        {
            if (ColumnExists(dataReader, propertyInfo.Name))
            {
                object value = GetValue(dataReader, propertyInfo.Name);
                if (typeof(bool).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    bool b = null != value && (true.Equals(value) || 1.Equals(value) || "1".Equals(value.ToString()));
                    propertyInfo.GetSetMethod().Invoke(o, new object[] { b });
                }
                else propertyInfo.GetSetMethod().Invoke(o, new object[] { value });
            }
            return o;
        }


        public static void Populate(object o, object value, PropertyInfo propertyInfo)
        {
            MethodInfo setMethod = propertyInfo.GetSetMethod();
            if (null != setMethod)
            {
                if (typeof(bool).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    bool b = null != value && (true.Equals(value) || 1.Equals(value) || "1".Equals(value.ToString()));
                    setMethod.Invoke(o, new object[] { b });
                }
                else 
                    setMethod.Invoke(o, new object[] { value });
            }
        }

        private static bool ColumnExists(DataRow dataRow, string key)
        {
            foreach (DataColumn column in dataRow.Table.Columns)
                if (column.ColumnName.ToUpper().Equals(key.ToUpper()))
                    return true;

            return false;
        }

        public static SqlDbType GetDBType(Type theType)
        {
            SqlParameter param;
            TypeConverter tc;
            param = new SqlParameter();
            tc = TypeDescriptor.GetConverter(param.DbType);
            if (tc.CanConvertFrom(theType))
                param.DbType = (DbType)tc.ConvertFrom(theType.Name);
            else
            {
                // try to forcefully convert
                try
                {
                    param.DbType = (DbType)tc.ConvertFrom(theType.Name);
                }
                catch (Exception e)
                {
                    // ignore the exception
                }
            }
            return param.SqlDbType;
        }

        public static void ResetTimer(Timer timer)
        {
            timer.Stop();
            timer.Start();
        }

    }
}
