using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using DNTv2.DataAccess;
using DNTv2.DataAccess.Services;
using DNTv2.DataModel;

namespace DNTDataAccess.DataServices
{
    public class KorisnikDataService : AbstractAutoDataService
    {
        public void PromjeniKorisnika(Korisnik korisnik)
        {
            using (OleDbCommand command 
                = new OleDbCommand("UPDATE DNTKorisnici SET ime = ?, prezime = ?, ulica = ?, kucni = ?, mjesto = ?, telefon = ? WHERE ID = ?"))
            {
                command.Parameters.Add("@ime", OleDbType.VarChar, 50).Value = korisnik.Ime;
                command.Parameters.Add("@prezime", OleDbType.VarChar, 50).Value = korisnik.Prezime ?? (object) DBNull.Value;
                command.Parameters.Add("@ulica", OleDbType.VarChar, 50).Value = korisnik.Adresa ?? (object) DBNull.Value;
                command.Parameters.Add("@kucni", OleDbType.VarChar, 50).Value = korisnik.KucniBroj ?? (object) DBNull.Value;
                command.Parameters.Add("@mjesto", OleDbType.VarChar, 50).Value = korisnik.Grad ?? (object) DBNull.Value;
                command.Parameters.Add("@telefon", OleDbType.VarChar, 50).Value = korisnik.Telefon ?? (object) DBNull.Value;
                command.Parameters.Add("@ID", OleDbType.Integer).Value = korisnik.Id;

                ExecuteNonQuery(command);
            }
        }

        public void UnesiKorisnika(Korisnik korisnik)
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                
                OleDbCommand command =
                    new OleDbCommand("INSERT INTO DNTKorisnici (ime, prezime, ulica, kucni, mjesto, telefon) Values (?, ?, ?, ?, ?, ?)", connection);

                command.Parameters.Add("@ime", OleDbType.VarChar, 50).Value = korisnik.Ime;
                command.Parameters.Add("@prezime", OleDbType.VarChar, 50).Value = korisnik.Prezime ?? (object)DBNull.Value;
                command.Parameters.Add("@ulica", OleDbType.VarChar, 50).Value = korisnik.Adresa ?? (object)DBNull.Value;
                command.Parameters.Add("@kucni", OleDbType.VarChar, 50).Value = korisnik.KucniBroj ?? (object)DBNull.Value;
                command.Parameters.Add("@mjesto", OleDbType.VarChar, 50).Value = korisnik.Grad ?? (object)DBNull.Value;
                command.Parameters.Add("@telefon", OleDbType.VarChar, 50).Value = korisnik.Telefon ?? (object)DBNull.Value;
                
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
            foreach (Kartica kartica in ObjectFactory.KarticaDataService.DajKarticeKorisnika(korisnik.Id))
                ObjectFactory.KarticaDataService.ObrisiKarticu(kartica);

            OleDbCommand command = new OleDbCommand("DELETE FROM DNTKorisnici WHERE ID = ?");
            command.Parameters.Add("@ID", OleDbType.Integer).Value = korisnik.Id;

            ExecuteNonQuery(command);
        }

        public IList<Korisnik> DajSveKorisnike()
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                DataTable table = new DataTable();
                OleDbCommand command =
                    new OleDbCommand(
                        "SELECT Id, ime, prezime, ulica AS Adresa, kucni AS KucniBroj, mjesto AS Grad, telefon FROM DNTKorisnici ORDER BY ime, prezime",
                        connection);
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
                return list;
            }
        }

        public Korisnik KorisnikPoBrojuKartice(string brojKartice)
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                DataTable table = new DataTable();
                OleDbCommand command = new OleDbCommand("SELECT ko.* FROM Kartice ka INNER JOIN DNTKorisnici ko ON ka.VlasnikID = ko.ID WHERE ka.Broj = ?", connection);
                command.Parameters.Add("@Broj", OleDbType.VarChar).Value = brojKartice;

                try
                {
                    connection.Open();
                    new OleDbDataAdapter(command).Fill(table);
                }
                finally
                {
                    connection.Close();
                }
                if (table.Rows.Count > 0)
                {
                    var o = CreateObject();
                    Utils.Populate(o, table.Rows[0]);
                    return o as Korisnik;
                }
            }
            return null;
        }
        
        public override Type ObjectType
        {
            get { return typeof(Korisnik); }
        }
    }
}
