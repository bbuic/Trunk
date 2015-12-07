using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using DNTDataAccess;
using DNTv2.DataModel;

namespace DNTv2.DataAccess.Services
{
    public class TransakcijaDataService: AbstractAutoDataService
    {
        public void PromjeniTransakciju(Transakcija transakcija)
        {
            OleDbCommand command = new OleDbCommand("UPDATE DNTTransakcije SET vrecica = ?, odlazak = ? WHERE dolazak = ?");

            command.Parameters.Add("@vrecica", OleDbType.SmallInt).Value = transakcija.BrojVrecica;
            command.Parameters.Add("@odlazak", OleDbType.Date).Value = transakcija.DatumDo ?? (object)DBNull.Value;
            command.Parameters.Add("@dolazak", OleDbType.Date).Value = transakcija.DatumOd;

            ExecuteNonQuery(command);
        }

        public void UnesiTransakciju(Transakcija transakcija)
        {
            OleDbCommand command = new OleDbCommand("INSERT INTO DNTTransakcije (kartica, dolazak, vrecica, odlazak, trezor) VALUES (?, ?, ?, ?, ?)");

            command.Parameters.Add("@kartica", OleDbType.VarChar).Value = transakcija.Kartica;
            command.Parameters.Add("@dolazak", OleDbType.Date).Value = transakcija.DatumOd;
            command.Parameters.Add("@vrecica", OleDbType.SmallInt).Value = transakcija.BrojVrecica;
            command.Parameters.Add("@odlazak", OleDbType.Date).Value = transakcija.DatumDo ?? (object)DBNull.Value;
            command.Parameters.Add("@trezor", OleDbType.Boolean).Value = transakcija.Trezor;

            ExecuteNonQuery(command);
        }

        public void IsprazniTrezor()
        {            
            OleDbCommand command = new OleDbCommand("UPDATE SISTEM SET TREZOR_PRAZAN_VRIJEME = ? WHERE ID = 1");
            command.Parameters.Add("@VrijemePraznjenja", OleDbType.Date).Value = DateTime.Now;                
            ExecuteNonQuery(command);

            command = new OleDbCommand("UPDATE DNTTransakcije SET Trezor = false WHERE Trezor = true");                
            ExecuteNonQuery(command);
        }

        public IList<Transakcija> DajTransakcije(DateTime? datumOd = null, DateTime? datumDo = null)
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT tr.kartica, ko.ime, ko.prezime, tr.dolazak AS DatumOd, tr.vrecica AS BrojVrecica, tr.odlazak AS DatumDo, tr.trezor ");
                builder.Append("FROM (Kartice AS ka INNER JOIN DNTKorisnici AS ko ON ka.VlasnikID = ko.ID) ");
                builder.Append("INNER JOIN DNTTransakcije AS tr ON ka.Broj = tr.kartica ");
                builder.Append("WHERE ");
                if (datumOd.HasValue && datumDo.HasValue)
                    builder.Append("tr.dolazak >= ? AND tr.dolazak <= ? ");
                else
                    builder.Append("tr.trezor = True ");
                builder.Append("ORDER BY tr.dolazak DESC");

                DataTable table = new DataTable();
                OleDbCommand command = new OleDbCommand(builder.ToString(), connection);

                if (datumOd.HasValue && datumDo.HasValue)
                {
                    command.Parameters.Add("@DatumOd", OleDbType.Date).Value = datumOd; 
                    command.Parameters.Add("@DatumDo", OleDbType.Date).Value = datumDo; 
                }
                try
                {
                    connection.Open();
                    new OleDbDataAdapter(command).Fill(table);
                }
                finally
                {
                    connection.Close();    
                }

                return ToList<Transakcija>(GetArrayList(table));
            }
        }

        public int DajBrojVrecicaUTrezoru()
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                OleDbCommand command = new OleDbCommand("SELECT Sum(vrecica) FROM DNTTransakcije WHERE trezor = True", connection);
                try
                {
                    connection.Open();
                    object o = command.ExecuteScalar();
                    return o is double || o is int ? int.Parse(o.ToString()) : 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DateTime ZadnjePraznjenjeTrezora()
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                OleDbCommand command = new OleDbCommand("SELECT TREZOR_PRAZAN_VRIJEME FROM SISTEM WHERE ID = 1", connection);
                try
                {
                    connection.Open();
                    return DateTime.Parse(command.ExecuteScalar().ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public override Type ObjectType
        {
            get { return typeof (Transakcija); }
        }
    }
}
