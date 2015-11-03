using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using DNTv2.DataModel;

namespace DNTv2.DataAccess.Services
{
    public class KarticaDataService:AbstractAutoDataService
    {
        public void Update(Kartica kartica)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand("UPDATE Kartice SET Ugovor = ?, Datum = ? WHERE Broj = ?", connection);

                command.Parameters.Add("@Ugovor", OleDbType.VarChar).Value = kartica.Ugovor ?? (object)DBNull.Value;
                command.Parameters.Add("@Datum", OleDbType.Date).Value = kartica.Datum;
                command.Parameters.Add("@Broj", OleDbType.VarChar).Value = kartica.Broj;

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

        public void Insert(Kartica kartica)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {

                OleDbCommand command =
                    new OleDbCommand("INSERT INTO Kartice (Broj, VlasnikID, Ugovor, Datum) Values (?, ?, ?, ?)", connection);

                command.Parameters.Add("@Broj", OleDbType.VarChar).Value = kartica.Broj;
                command.Parameters.Add("@VlasnikID", OleDbType.Integer).Value = kartica.VlasnikId;
                command.Parameters.Add("@Ugovor", OleDbType.VarChar).Value = kartica.Ugovor ?? (object)DBNull.Value;
                command.Parameters.Add("@Datum", OleDbType.Date).Value = kartica.Datum;

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

        public void ObrisiKarticu(Kartica kartica)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Kartice WHERE Broj = ?", connection);
                command.Parameters.Add("@Broj", OleDbType.VarChar).Value = kartica.Broj;

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

        public IList<Kartica> DajKarticeKorisnika(int korisnikId)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                DataTable table = new DataTable();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Kartice WHERE VlasnikID = ?", connection);
                command.Parameters.Add("@VlasnikID", OleDbType.Integer).Value = korisnikId;
                try
                {
                    connection.Open();
                    new OleDbDataAdapter(command).Fill(table);
                }
                finally
                {
                    connection.Close();
                }
                return ToList<Kartica>(GetArrayList(table));
            }
        }

        public override Type ObjectType
        {
            get { return typeof (Kartica); }
        }
    }
}
