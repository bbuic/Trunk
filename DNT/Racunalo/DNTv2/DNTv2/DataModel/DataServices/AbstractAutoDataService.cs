using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using DNTv2.DataModel.Attributes;

namespace DNTv2.DataModel.DataServices
{
    public abstract class AbstractAutoDataService : AbstractDataService
    {
        protected override object CreateObject()
        {
            return ObjectType.Assembly.CreateInstance(ObjectType.FullName);
        }

        public abstract Type ObjectType { get; }

        public virtual IList FindAll()
        {
            SqlCommand sqlCommand = new SqlCommand("select * " + FromAllSql());
            return FindAll(sqlCommand);
        }

        public virtual int CountAll()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT Count(*) " + FromAllSql());
            return (int)FindFirstValue(sqlCommand);
        }

        public virtual bool ExistsById(object id)
        {
            PropertyInfo idProperty = IdProperty;
            if (null == idProperty)
                return false;

            SqlCommand sqlCommand = new SqlCommand("select Count(*) " + FromByIdSql());
            if (null == id)
            {
                sqlCommand.Parameters.Add("@" + idProperty.Name, Utils.GetDBType(idProperty.PropertyType)).Value =
                    DBNull.Value;
            }
            else
                sqlCommand.Parameters.Add("@" + idProperty.Name, Utils.GetDBType(idProperty.PropertyType)).Value = id;
            return FindFirstBool(sqlCommand);
        }

        public bool ExistsUnique(params object[] uk)
        {
            SqlCommand sqlCommand = new SqlCommand("select Count(*) " + FromByUniqueSql());
            PropertyInfo[] uniqueProperties = UniqueProperties;
            for (int i = 0; i < uniqueProperties.Length; i++)
            {
                PropertyInfo propertyInfo = uniqueProperties[i];
                if (null == uk[i])
                {
                    sqlCommand.Parameters.Add("@" + propertyInfo.Name, Utils.GetDBType(propertyInfo.PropertyType)).Value =
                        DBNull.Value;
                }
                else
                    sqlCommand.Parameters.Add("@" + propertyInfo.Name, Utils.GetDBType(propertyInfo.PropertyType)).Value = uk[i];
            }
            return FindFirstBool(sqlCommand);
        }


        public virtual object FindById(object id, SqlTransaction transaction)
        {
            PropertyInfo idProperty = IdProperty;
            if (null == idProperty)
                return null;

            SqlCommand sqlCommand = new SqlCommand("select * " + FromByIdSql());
            sqlCommand.Transaction = transaction;
            if (id is int && 0.Equals(id))
            {
                sqlCommand.Parameters.Add("@" + idProperty.Name, Utils.GetDBType(idProperty.PropertyType)).Value =
                    DBNull.Value;
            }
            else
                sqlCommand.Parameters.Add("@" + idProperty.Name, Utils.GetDBType(idProperty.PropertyType)).Value = id;
            return FindFirst(sqlCommand);
        }

        public virtual object FindById(object id)
        {
            return FindById(id, null);
        }

        public virtual object FindByUnique(params object[] uk)
        {
            SqlCommand sqlCommand = new SqlCommand("select * " + FromByUniqueSql());
            PropertyInfo[] uniqueProperties = UniqueProperties;
            for (int i = 0; i < uniqueProperties.Length; i++)
            {
                PropertyInfo propertyInfo = uniqueProperties[i];
                SetParameter(sqlCommand, "@" + propertyInfo.Name, propertyInfo.PropertyType, uk[i]);
            }
            return FindFirst(sqlCommand);
        }

    /*    public virtual object FindByColumn(string column, object value)
        {
            if (!ExistsProperty(column))
                throw new ColumnNameFailException("Pogresan naziv kolone : " + column);

            SqlCommand sqlCommand = new SqlCommand("select * from [" + ObjectType.Name + "] where " + column + " = @" + column);

            PropertyInfo property = ObjectType.GetProperty(column);
            if (value != null && value.GetType() != property.PropertyType)
                throw new ColumnTypeFailException("Pogresan tip podatka kolone : " + value.GetType());

            if (value != null)
            {
                if (value is ITipovi)
                    sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value = value.GetType().GetProperty("DBVrijednost").GetValue(value, null);
                else
                    sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value = value;
            }
            else
                sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value =
                    DBNull.Value;

            return FindFirst(sqlCommand);
        }

        public IList FindAllByColumn(string column, object value)
        {
            if (!ExistsProperty(column))
                throw new ColumnNameFailException("Pogresan naziv kolone : " + column);

            SqlCommand sqlCommand = new SqlCommand("select * from [" + ObjectType.Name + "] where " + column + " = @" + column);

            PropertyInfo property = ObjectType.GetProperty(column);
            if (value != null && value.GetType() != property.PropertyType)
                throw new ColumnTypeFailException(
                    "Pogresan tip podatka kolone ! Tip pod. :" + value.GetType() + " , tip kolone : " + property.PropertyType);

            if (value != null)
            {
                if (value is ITipovi)
                    sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value = value.GetType().GetProperty("DBVrijednost").GetValue(value, null);
                else
                    sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value = value;
            }
            else
                sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value =
                    DBNull.Value;

            return FindAll(sqlCommand);
        }

        public bool ExistsByColumn(string column, object value)
        {
            if (!ExistsProperty(column))
                throw new ColumnNameFailException("Pogresan naziv kolone : " + column);

            SqlCommand sqlCommand = new SqlCommand("select Count(*) from [" + ObjectType.Name + "] where " + column + " = @" + column);

            PropertyInfo property = ObjectType.GetProperty(column);
            if (value != null && value.GetType() != property.PropertyType)
                throw new ColumnTypeFailException("Pogresan tip podatka kolone : " + value.GetType());

            if (value != null)
            {
                if (value is ITipovi)
                    sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value = value.GetType().GetProperty("DBVrijednost").GetValue(value, null);
                else
                    sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value = value;
            }
            else
                sqlCommand.Parameters.Add("@" + property.Name, Utils.GetDBType(property.PropertyType)).Value =
                    DBNull.Value;

            return FindFirstBool(sqlCommand);
        }*/

        private bool ExistsProperty(string column)
        {
            foreach (PropertyInfo propertyInfo in ObjectType.GetProperties())
            {
                if (column == propertyInfo.Name)
                    return true;
            }
            return false;
        }



        public virtual void Save(object o)
        {
            if (null == o)
                throw new ArgumentNullException("o");
            if (!ObjectType.IsAssignableFrom(o.GetType()))
                throw new ArgumentException("Invalid object type!");

            PropertyInfo idProperty = IdProperty;
            if (null != idProperty)
            {
                object id = idProperty.GetValue(o, null);
                if (null == id || (id is int && 0.Equals(id)) || !ExistsById(id))
                    Insert(o);
                else
                    Update(o);
            }
            else
                Insert(o);
        }

        public virtual void SaveAll(ICollection list)
        {
            SaveAll(list, 0);
        }

        public void SaveAll(ICollection list, int chunkSize)
        {
            using (SqlConnection connection = base.SqlConnection)
            {
                if (!connection.State.Equals(ConnectionState.Open))
                    connection.Open();
                int index = 0;
                StringBuilder sql = new StringBuilder();
                SqlCommand sqlCommand = new SqlCommand();
                foreach (PersistentObject o in list)
                {
                    index++;
                    if (index > chunkSize && chunkSize > 0)
                    {
                        sqlCommand.CommandText = sql.ToString();
                        Execute(connection, sqlCommand);

                        index = 1;
                        sql = new StringBuilder();
                        sqlCommand = new SqlCommand();
                    }
                    if (o.Id <= 0)
                        sql.Append(GetInsertSQL(index, false, o)).Append("\r\n");
                    else
                        sql.Append(GetUpdateSQL(index)).Append("\r\n");
                    foreach (PropertyInfo propertyInfo in ObjectType.GetProperties())
                        if (!IsIgnoredProperty(propertyInfo))
                        {
                            SetParameter(sqlCommand, "@" + propertyInfo.Name + index, propertyInfo.PropertyType,
                                         propertyInfo.GetValue(o, null));
                        }
                }
                if (sql.Length > 0)
                {
                    sqlCommand.CommandText = sql.ToString();
                    Execute(connection, sqlCommand);
                }
            }
        }

        protected string GetUpdateSQL(int index)
        {
            StringBuilder sql = new StringBuilder("update " + ObjectType.Name + " set ");
            PropertyInfo id = IdProperty;

            foreach (PropertyInfo propertyInfo in ObjectType.GetProperties())
                if ((null == id.Name || !id.Name.Equals(propertyInfo.Name)) && !IsIgnoredProperty(propertyInfo))
                {
                    sql.Append("[" + propertyInfo.Name).Append("] = @").Append(propertyInfo.Name + (index > 0 ? index.ToString() : ""))
                        .Append(", ");
                }

            if (sql.ToString(sql.Length - 2, 2).Equals(", "))
                sql.Remove(sql.Length - 2, 2);

            sql.Append(" where ").Append(id.Name).Append(" = @").Append(id.Name + (index > 0 ? index.ToString() : ""));
            return sql.ToString();
        }

        private string GetInsertSQL(int index, bool returnId, object o)
        {
            StringBuilder sql =
                new StringBuilder("insert into " + ObjectType.Name + " ($,) values (#,)" +
                                  (returnId ? "\r\nSELECT SCOPE_IDENTITY()" : ""));
            PropertyInfo idProperty = IdProperty;
            object id = null;
            if (null != idProperty)
            {
                id = idProperty.GetValue(o, null);
                if (id is int && 0.Equals(id))
                    id = null;
            }

            foreach (PropertyInfo propertyInfo in ObjectType.GetProperties())
            {
                if (!IsIgnoredProperty(propertyInfo) && !(idProperty.Name.Equals(propertyInfo.Name) && null == id))
                {
                    sql.Replace("$,", "[" + propertyInfo.Name + "], $,");
                    sql.Replace("#,", "@" + propertyInfo.Name + (index > 0 ? index.ToString() : "") + ", #,");
                }
            }
            sql.Replace(", $,", "");
            sql.Replace(", #,", "");
            return sql.ToString();
        }

        public void Insert(object o)
        {
            BeforeInsert(o);
            InsertInTransaction(o, null);
        }

        public void InsertInTransaction(object o, SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = new SqlCommand(GetInsertSQL(0, true, o));
            foreach (PropertyInfo propertyInfo in ObjectType.GetProperties())
                if (!IsIgnoredProperty(propertyInfo))
                    SetParameter(sqlCommand, "@" + propertyInfo.Name, propertyInfo.PropertyType, propertyInfo.GetValue(o, null));

            if (sqlTransaction != null)
                sqlCommand.Transaction = sqlTransaction;

            object value = FindFirstValue(sqlCommand);
            if (null != value && !DBNull.Value.Equals(value))
            {
                if (typeof(int).IsAssignableFrom(IdProperty.PropertyType))
                    IdProperty.SetValue(o, int.Parse(value.ToString()), null);
                else
                    IdProperty.SetValue(o, value, null);
            }
        }

        /// <summary>
        /// Ovo je tu za slučaj da npr. nema autogenerirajući IS
        /// </summary>
        /// <param name="o"></param>
        protected virtual void BeforeInsert(object o)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID">Identifikator row-a kojeg se želi updejtati</param>
        /// <param name="kolonaVrijednostPairs">NazivKolone = "Naziv kolone", VrijednostKolone = "Vrijednost na koju se želi updejtati"</param>
       /* public void UpdateColumns(object ID, KolonaVrijednostPair[] kolonaVrijednostPairs, SqlTransaction transaction)
        {
            if (ID == null)
                throw new ArgumentNullException("ID");
            if (kolonaVrijednostPairs == null)
                throw new ArgumentNullException("kolonaVrijednost");

            SqlCommand sqlCommand = new SqlCommand();

            StringBuilder sql = new StringBuilder("update " + ObjectType.Name + " set ");
            PropertyInfo id = IdProperty;

            foreach (KolonaVrijednostPair pair in kolonaVrijednostPairs)
            {
                bool kolonaPronadena = false;
                foreach (PropertyInfo propertyInfo in ObjectType.GetProperties())
                {
                    if (Equals(propertyInfo.Name.ToLower(), pair.NazivKolone.ToString().ToLower()))
                    {
                        kolonaPronadena = true;
                        sql.Append("[" + pair.NazivKolone).Append("] = @").Append(pair.NazivKolone).Append(", ");
                        SetParameter(sqlCommand, "@" + pair.NazivKolone, propertyInfo.PropertyType, pair.VrijednostKolone);
                        break;
                    }
                }
                if (!kolonaPronadena) throw new ArgumentException("Kolona " + pair.NazivKolone + " nije pronađena !");
            }
            SetParameter(sqlCommand, "@" + id.Name, id.PropertyType, ID);

            if (sql.ToString(sql.Length - 2, 2).Equals(", "))
                sql.Remove(sql.Length - 2, 2);

            sql.Append(" where ").Append(id.Name).Append(" = @").Append(id.Name);

            sqlCommand.CommandText = sql.ToString();
            if (transaction != null)
                sqlCommand.Transaction = transaction;
            Execute(sqlCommand);
        }*/

        public void Update(object o)
        {
            UpdateInTransaction(o, null);
        }

        public void UpdateInTransaction(object o, SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = new SqlCommand(GetUpdateSQL(0));
            foreach (PropertyInfo propertyInfo in ObjectType.GetProperties())
                if (!IsIgnoredProperty(propertyInfo))
                    SetParameter(sqlCommand, "@" + propertyInfo.Name, propertyInfo.PropertyType, propertyInfo.GetValue(o, null));

            if (sqlTransaction != null)
                sqlCommand.Transaction = sqlTransaction;

            Execute(sqlCommand);
        }


        public static void SetParameter(SqlCommand sqlCommand, string paramName, Type type, object value)
        {
            if (typeof(bool).IsAssignableFrom(type))
                sqlCommand.Parameters.Add(paramName, SqlDbType.Bit).Value = null != value && (bool)value ? 1 : 0;
            else
                sqlCommand.Parameters.Add(paramName, Utils.GetDBType(type)).Value = value;
        }

        public void DeleteAll()
        {
            Execute(new SqlCommand("delete " + ObjectType.Name));
        }

        public void DeleteList(IList list)
        {
            foreach (PersistentObject o in list)
            {
                Delete(o);
            }
        }
        public virtual void Delete(object o)
        {
            DeleteInTransaction(o, null);
        }

        public virtual void DeleteInTransaction(object o, SqlTransaction transaction)
        {
            StringBuilder sql = new StringBuilder("delete " + ObjectType.Name);
            PropertyInfo id = IdProperty;

            sql.Append(" where ").Append(id.Name).Append(" = @").Append(id.Name);

            SqlCommand sqlCommand = new SqlCommand(sql.ToString());
            object obj = id.GetValue(o, null);
            if (null == obj)
            {
                sqlCommand.Parameters.Add("@" + id.Name, Utils.GetDBType(id.PropertyType)).Value =
                    DBNull.Value;
            }
            else
                sqlCommand.Parameters.Add("@" + id.Name, Utils.GetDBType(id.PropertyType)).Value = obj;

            if (transaction != null)
                sqlCommand.Transaction = transaction;
            Execute(sqlCommand);
        }

        protected virtual string FromByIdSql()
        {
            PropertyInfo property = IdProperty;
            return FromAllSql() + " where o." + property.Name + " = @" + property.Name + " ";
        }

        protected virtual string FromByUniqueSql()
        {
            StringBuilder hql = new StringBuilder(FromAllSql());
            bool first = true;
            foreach (PropertyInfo property in UniqueProperties)
            {
                if (first)
                {
                    hql.Append(" where ");
                    first = false;
                }
                else
                    hql.Append(" and ");
                hql.Append("o.").Append(property.Name).Append(" = @" + property.Name + " ");
            }
            return hql.ToString();
        }

        protected virtual string FromAllSql()
        {
            return FromAllSql("o");
        }

        protected virtual string FromAllSql(string alias)
        {
            return "from [" + ObjectType.Name + "] " + alias + " ";
        }

        public PropertyInfo[] UniqueProperties
        {
            get { return AttributeUtils.GetPropertiesWithAttribute(ObjectType, typeof(UniqueAttribute)); }
        }

        public PropertyInfo[] IgnoredProperties
        {
            get { return AttributeUtils.GetPropertiesWithAttribute(ObjectType, typeof(IgnoreAttribute)); }
        }

        public PropertyInfo IdProperty
        {
            get
            {
                PropertyInfo[] properties = AttributeUtils.GetPropertiesWithAttribute(ObjectType, typeof(IdAttribute));
                return properties.Length > 0 ? properties[0] : null;
            }
        }

        protected static void Execute(SqlConnection connection, SqlCommand sqlCommand)
        {
            sqlCommand.Connection = connection;
            sqlCommand.ExecuteNonQuery();
        }

        protected void SetProperties(int index, PersistentObject o, SqlCommand sqlCommand, params string[] ignore)
        {
            ArrayList ignoreList = new ArrayList();
            if (null != ignore)
                ignoreList.AddRange(ignore);
            foreach (PropertyInfo propertyInfo in ObjectType.GetProperties())
                if (!IsIgnoredProperty(propertyInfo) && !ignoreList.Contains(propertyInfo.Name))
                {
                    SetParameter(sqlCommand, "@" + propertyInfo.Name + index, propertyInfo.PropertyType,
                                 propertyInfo.GetValue(o, null));
                }
        }

        private bool IsIgnoredProperty(PropertyInfo propertyInfo)
        {
            ArrayList ignoreList = new ArrayList();
            ignoreList.AddRange(IgnoredProperties);
            return ignoreList.Contains(propertyInfo);
        }

    }
}
