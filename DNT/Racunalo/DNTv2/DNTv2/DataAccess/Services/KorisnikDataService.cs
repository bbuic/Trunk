using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace DNTv2.DataAccess.Services
{
    public class KorisnikDataService : AbstractAutoDataService
    {
        public void PromjeniKorisnika(Korisnik korisnik)
        {            
            OleDbCommand command = new OleDbCommand("UPDATE DNTKorisnici SET ime = ?, prezime = ?, ulica = ?, kucni = ?, mjesto = ?, telefon = ? WHERE ID = ?");

            command.Parameters.Add("@ime", OleDbType.VarChar).Value = korisnik.Ime;
            command.Parameters.Add("@prezime", OleDbType.VarChar).Value = korisnik.Prezime ?? (object)DBNull.Value;
            command.Parameters.Add("@ulica", OleDbType.VarChar).Value = korisnik.Adresa ?? (object)DBNull.Value;
            command.Parameters.Add("@kucni", OleDbType.VarChar).Value = korisnik.KucniBroj ?? (object)DBNull.Value;
            command.Parameters.Add("@mjesto", OleDbType.VarChar).Value = korisnik.Grad ?? (object)DBNull.Value;
            command.Parameters.Add("@telefon", OleDbType.VarChar).Value = korisnik.Telefon ?? (object)DBNull.Value;
            command.Parameters.Add("@ID", OleDbType.Integer).Value = korisnik.Id;
                
             ExecuteNonQuery(command);
        }

        public void UnesiKorisnika(Korisnik korisnik)
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                
                OleDbCommand command =
                    new OleDbCommand("INSERT INTO DNTKorisnici (ime, prezime, ulica, kucni, mjesto, telefon) Values (?, ?, ?, ?, ?, ?)", connection);
                
                command.Parameters.Add("@ime", OleDbType.VarChar).Value = korisnik.Ime;
                command.Parameters.Add("@prezime", OleDbType.VarChar).Value = korisnik.Prezime ?? (object) DBNull.Value;
                command.Parameters.Add("@ulica", OleDbType.VarChar).Value = korisnik.Adresa ?? (object)DBNull.Value;
                command.Parameters.Add("@kucni", OleDbType.VarChar).Value = korisnik.KucniBroj ?? (object)DBNull.Value;
                command.Parameters.Add("@mjesto", OleDbType.VarChar).Value = korisnik.Grad ?? (object)DBNull.Value;
                command.Parameters.Add("@telefon", OleDbType.VarChar).Value = korisnik.Telefon ?? (object)DBNull.Value;
                
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    OleDbCommand dbCommand = new OleDbCommand("SELECT @@IDENTITY", connection);
                    korisnik.Id = (int) dbCommand.ExecuteScalar();
                }
                finally
                {
                    connection.Close();
                }
            } 
        }

        public void ObrisiKorisnika(Korisnik korisnik)
        {
            OleDbCommand command = new OleDbCommand("DELETE FROM DNTKorisnici WHERE ID = ?");
            command.Parameters.Add("@ID", OleDbType.Integer).Value = korisnik.Id;

            ExecuteNonQuery(command);
        }

        public IList<Korisnik> DajSveKorisnike()
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                DataTable table = new DataTable();
                OleDbCommand command = new OleDbCommand("SELECT Id, ime, prezime, ulica AS Adresa, kucni AS KucniBroj, mjesto AS Grad, telefon FROM DNTKorisnici ORDER BY ime, prezime", connection);
                try
                {
                    connection.Open();
                    new OleDbDataAdapter(command).Fill(table);
                }
                finally
                {
                    connection.Close();
                }

                IList<Korisnik> list = ToList<Korisnik>(GetArrayList(table));
                //foreach (Korisnik korisnik in list)
                //{
                //    korisnik.Kartice = ObjectFactory.KarticaDataService.DajKarticeKorisnika(korisnik.Id);
                //}
                return list;
            }
        }
        
        public override Type ObjectType
        {
            get { return typeof(Korisnik); }
        }
    }
}
