using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using DNTv2.DataModel;

namespace DNTv2.DataAccess.Services
{
    public class TransakcijaDataService: AbstractAutoDataService
    {
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
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
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
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand("SELECT Sum(vrecica) FROM DNTTransakcije WHERE trezor = True", connection);
                try
                {
                    connection.Open();
                    return int.Parse(command.ExecuteScalar().ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DateTime ZadnjePraznjenjeTrezora()
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
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
