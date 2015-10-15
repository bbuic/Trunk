using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DNTv2.DataModel.DataServices
{
    public abstract class AbstractDataService
    {
        public delegate void BazaPostaviPodatke(SqlCommand sqlCommand);
        internal ISqlConnectionProvider sqlConnectionProvider = new DefaultSqlConnectionProvider();
        private object tmpObject;

        public ISqlConnectionProvider SqlConnectionProvider
        {
            get { return sqlConnectionProvider; }
            set { sqlConnectionProvider = value; }
        }

        protected bool FindFirstBool(SqlCommand command)
        {
            object value = FindFirstValue(command);
            return null != value && (bool)System.Convert.ChangeType(value, typeof(bool));
        }

        protected long FindFirstLong(SqlCommand command)
        {
            object value = FindFirstValue(command);
            return null != value ? (long)System.Convert.ChangeType(value, typeof(long)) : 0;
        }

        protected int FindFirstInt(SqlCommand command, CommandType commandType, SqlTransaction transaction)
        {
            command.Transaction = transaction;
            object value = FindFirstValue(command, commandType);
            return null != value ? (int)System.Convert.ChangeType(value, typeof(int)) : 0;
        }
        protected int FindFirstInt(SqlCommand command)
        {
            object value = FindFirstValue(command);
            return null != value ? (int)System.Convert.ChangeType(value, typeof(int)) : 0;
        }

        protected object FindFirstValue(SqlCommand command, CommandType commandType)
        {
            DataTable dataTable = DohvatiTablicu(command, commandType);
            if (dataTable != null && dataTable.Rows.Count > 0)
                return dataTable.Rows[0][0];
            return null;
        }

        protected object FindFirstValue(SqlCommand command)
        {
            DataTable dataTable = DohvatiTablicu(command, CommandType.Text);
            if (dataTable != null && dataTable.Rows.Count > 0)
                return dataTable.Rows[0][0];
            return null;
        }

        protected DataRow FindFirstRow(SqlCommand command, CommandType commandType)
        {
            DataTable dataTable = DohvatiTablicu(command, commandType);

            if (dataTable != null && dataTable.Rows.Count > 0)
                return dataTable.Rows[0];

            return null;
        }

        protected object FindFirst(SqlCommand command, CommandType commandType)
        {
            DataTable dataTable = DohvatiTablicu(command, commandType);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                object o = CreateObject();
                Utils.Populate(o, dataTable.Rows[0]);
                return o;
            }
            return null;
        }

        protected object FindFirst(SqlCommand command, CommandType commandType, SqlTransaction transaction)
        {
            command.Transaction = transaction;
            return FindFirst(command, commandType);
        }

        protected object FindFirst(SqlCommand command, SqlTransaction transaction)
        {
            command.Transaction = transaction;
            return FindFirst(command);
        }

        protected object FindFirst(SqlCommand command)
        {
            DataTable dataTable = DohvatiTablicu(command, CommandType.Text);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                object o = CreateObject();
                Utils.Populate(o, dataTable.Rows[0]);
                return o;
            }
            return null;
        }

        protected object FindFirst(SqlCommand command, object o)
        {
            DataTable dataTable = DohvatiTablicu(command, CommandType.Text);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Utils.Populate(o, dataTable.Rows[0]);
                return o;
            }
            return null;
        }

        protected ArrayList FindAll(SqlCommand command)
        {
            DataTable dataTable = DohvatiTablicu(command, CommandType.Text);
            return GetArrayList(dataTable);
        }

        protected IList<T> FindAll<T>(SqlCommand command)
        {
            return ToList<T>(GetArrayList(DohvatiTablicu(command, CommandType.Text)));
        }

        protected IList<T> FindAll<T>(SqlCommand command, CommandType commandType)
        {
            return ToList<T>(GetArrayList(DohvatiTablicu(command, commandType)));
        }

        protected ArrayList FindAll(SqlCommand command, CommandType commandType)
        {
            DataTable dataTable = DohvatiTablicu(command, commandType);
            return GetArrayList(dataTable);
        }

        protected ArrayList FindAll(SqlCommand command, CommandType commandType, object o)
        {
            tmpObject = o;
            DataTable dataTable = DohvatiTablicu(command, commandType);
            return GetArrayList(dataTable);
        }

        private ArrayList GetArrayList(DataTable dataTable)
        {
            ArrayList list = new ArrayList();
            if (dataTable != null && dataTable.Rows != null)
                foreach (DataRow row in dataTable.Rows)
                {
                    object o = GetObject();
                    Utils.Populate(o, row);
                    list.Add(o);
                }
            return list;
        }

        private object GetObject()
        {
            return tmpObject != null ? tmpObject : CreateObject();
        }

        protected void Execute(SqlCommand command, CommandType commandType, int timeOut)
        {
            command.CommandTimeout = timeOut;
            Execute(command, commandType);
        }

        protected void Execute(SqlCommand command, CommandType commandType, SqlTransaction transaction)
        {
            command.Transaction = transaction;
            command.CommandType = commandType;
            Execute(command);
        }

        protected void Execute(SqlCommand command, CommandType commandType)
        {
            using (SqlConnection connection = SqlConnectionProvider.SqlConnection)
            {
                if (!connection.State.Equals(ConnectionState.Open))
                    connection.Open();
                using (command)
                {
                    if (!connection.State.Equals(ConnectionState.Open))
                        connection.Open();
                    command.Connection = connection;
                    command.CommandType = commandType;
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void Execute(SqlCommand command)
        {
            if (command.Transaction == null)
            {
                using (SqlConnection connection = SqlConnectionProvider.SqlConnection)
                {
                    if (!connection.State.Equals(ConnectionState.Open))
                        connection.Open();
                    using (command)
                    {
                        if (!connection.State.Equals(ConnectionState.Open))
                            connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                command.Connection = command.Transaction.Connection;
                command.ExecuteNonQuery();
            }
        }

        protected DataTable DohvatiTablicu(SqlCommand sqlCommand, CommandType commandType)
        {

            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.TableMappings.Add("Table", sqlCommand.CommandText);

            if (sqlCommand.Transaction == null)
            {
                using (SqlConnection connection = SqlConnectionProvider.SqlConnection)
                {
                    if (!connection.State.Equals(ConnectionState.Open))
                        connection.Open();

                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = commandType;

                    Adapter.SelectCommand = sqlCommand;
                    DataSet ds = new DataSet(sqlCommand.CommandText);
                    Adapter.Fill(ds);
                    return ds.Tables[sqlCommand.CommandText];
                }
            }
            else
            {
                sqlCommand.Connection = sqlCommand.Transaction.Connection;
                sqlCommand.CommandType = commandType;

                Adapter.SelectCommand = sqlCommand;
                DataSet ds = new DataSet(sqlCommand.CommandText);
                Adapter.Fill(ds);
                return ds.Tables[sqlCommand.CommandText];
            }
        }

        protected abstract object CreateObject();

        protected static void AddBoolParameter(SqlCommand command, string naziv, bool b)
        {
            AddParameter(command, naziv, SqlDbType.Bit, b ? 1 : 0);
        }

        protected static void AddParameter(SqlCommand command, string naziv, SqlDbType type, object value)
        {
            if (null != value)
                command.Parameters.Add(new SqlParameter(naziv, type)).Value = value;
            else
                command.Parameters.Add(new SqlParameter(naziv, type)).Value = DBNull.Value;
        }

        protected bool GetBool(object o)
        {
            return GetInt(o) > 0;
        }

        protected int GetInt(object o)
        {
            return (int)GetLong(o);
        }

        protected long GetLong(object o)
        {
            if (null != o && o.GetType().Equals(typeof(int)))
                return (int)o;
            if (null == o || DBNull.Value.Equals(o))
                return 0;
            else
            {
                try
                {
                    return long.Parse(o.ToString());
                }
                catch (Exception e)
                {
                    Console.Write(e);
                    return 0;
                }
            }
        }

        public List<T> ToList<T>(ArrayList arrayList)
        {
            return arrayList.Cast<T>().ToList();
        }

        public void Execute(SqlCommand sqlCommand, CommandType commandType, BazaPostaviPodatke postaviPodatke)
        {
            using (SqlConnection connection = SqlConnectionProvider.SqlConnection)
            {
                if (!connection.State.Equals(ConnectionState.Open))
                    connection.Open();
                using (sqlCommand)
                {
                    if (!connection.State.Equals(ConnectionState.Open))
                        connection.Open();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = commandType;
                    sqlCommand.ExecuteNonQuery();
                    postaviPodatke(sqlCommand);
                }
            }
        }
    }
}
