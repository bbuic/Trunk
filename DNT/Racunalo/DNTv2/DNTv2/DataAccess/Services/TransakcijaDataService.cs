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
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand("UPDATE SISTEM Set TREZOR_PRAZAN_VRIJEME = ? WHERE ID = 1", connection);
                command.Parameters.Add("@VrijemePraznjenja", OleDbType.Date).Value = DateTime.Now;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IList<Transakcija> DajSveUTrezoru()
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT DNTTransakcije.kartica, DNTKorisnici.ime, DNTKorisnici.prezime, DNTTransakcije.dolazak, DNTTransakcije.vrecica, DNTTransakcije.odlazak, DNTTransakcije.trezor ");
                builder.Append("FROM (Kartice INNER JOIN DNTKorisnici ON Kartice.VlasnikID = DNTKorisnici.ID) INNER JOIN DNTTransakcije ON Kartice.Broj = DNTTransakcije.kartica ");
                builder.Append("WHERE DNTTransakcije.trezor = True ORDER BY DNTTransakcije.dolazak DESC");

                DataTable table = new DataTable();
                OleDbCommand command = new OleDbCommand(builder.ToString(), connection);
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

        public short DajBrojVrecicaUTrezoru()
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand("SELECT Sum(vrecica) FROM DNTTransakcije WHERE trezor = True", connection);
                try
                {
                    connection.Open();
                    return (short) command.ExecuteScalar();
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
