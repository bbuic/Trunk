using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using DNTv2.DataModel;

namespace DNTv2.DataAccess.Services
{
    public class KarticaDataService:AbstractAutoDataService
    {
        public void Update(Korisnik korisnik)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                OleDbCommand command =
                    new OleDbCommand("UPDATE DNTKorisnici SET ime = ?, prezime = ?, ulica = ?, kucni = ?, mjesto = ?, telefon = ? WHERE ID = ?", connection);

                command.Parameters.Add("@ime", OleDbType.VarChar).Value = korisnik.Ime;
                command.Parameters.Add("@prezime", OleDbType.VarChar).Value = korisnik.Prezime ?? (object)DBNull.Value;
                command.Parameters.Add("@ulica", OleDbType.VarChar).Value = korisnik.Adresa ?? (object)DBNull.Value;
                command.Parameters.Add("@kucni", OleDbType.VarChar).Value = korisnik.KucniBroj ?? (object)DBNull.Value;
                command.Parameters.Add("@mjesto", OleDbType.VarChar).Value = korisnik.Grad ?? (object)DBNull.Value;
                command.Parameters.Add("@telefon", OleDbType.VarChar).Value = korisnik.Telefon ?? (object)DBNull.Value;
                command.Parameters.Add("@ID", OleDbType.Integer).Value = korisnik.Id;

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

        public void Insert(Korisnik korisnik)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {

                OleDbCommand command =
                    new OleDbCommand("INSERT INTO DNTKorisnici (ime, prezime, ulica, kucni, mjesto, telefon) Values (?, ?, ?, ?, ?, ?)", connection);

                command.Parameters.Add("@ime", OleDbType.VarChar).Value = korisnik.Ime;
                command.Parameters.Add("@prezime", OleDbType.VarChar).Value = korisnik.Prezime ?? (object)DBNull.Value;
                command.Parameters.Add("@ulica", OleDbType.VarChar).Value = korisnik.Adresa ?? (object)DBNull.Value;
                command.Parameters.Add("@kucni", OleDbType.VarChar).Value = korisnik.KucniBroj ?? (object)DBNull.Value;
                command.Parameters.Add("@mjesto", OleDbType.VarChar).Value = korisnik.Grad ?? (object)DBNull.Value;
                command.Parameters.Add("@telefon", OleDbType.VarChar).Value = korisnik.Telefon ?? (object)DBNull.Value;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    OleDbCommand dbCommand = new OleDbCommand("SELECT @@IDENTITY", connection);
                    korisnik.Id = (int)dbCommand.ExecuteScalar();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Delete(Korisnik korisnik)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM DNTKorisnici WHERE ID = ?", connection);
                command.Parameters.Add("@ID", OleDbType.Integer).Value = korisnik.Id;

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
