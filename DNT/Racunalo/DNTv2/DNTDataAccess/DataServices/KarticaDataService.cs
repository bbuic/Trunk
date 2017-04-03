using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using DNTDataAccess;
using DNTv2.DataModel;

namespace DNTv2.DataAccess.Services
{
    public class KarticaDataService:AbstractAutoDataService
    {
        public void PromjeniKarticu(Kartica kartica)
        {
            using (OleDbCommand command = new OleDbCommand("UPDATE Kartice SET Ugovor = ?, Datum = ?, Aktivnost = ?, OdgovornaOsoba = ? WHERE Broj = ?"))
            {
                command.Parameters.Add("@Ugovor", OleDbType.VarChar, 255).Value = kartica.Ugovor ?? (object) DBNull.Value;
                command.Parameters.Add("@Datum", OleDbType.Date).Value = kartica.Datum;
                command.Parameters.Add("@Aktivnost", OleDbType.Boolean).Value = kartica.Aktivnost;
                command.Parameters.Add("@OdgovornaOsoba", OleDbType.VarChar, 254).Value = kartica.OdgovornaOsoba ?? (object)DBNull.Value;
                command.Parameters.Add("@Broj", OleDbType.VarChar, 10).Value = kartica.Broj;                

                ExecuteNonQuery(command);
            }
        }

        public void UnesiKarticu(Kartica kartica)
        {
            using(OleDbCommand command = new OleDbCommand("INSERT INTO Kartice (Broj, VlasnikID, Ugovor, Datum, Aktivnost, OdgovornaOsoba) Values (?, ?, ?, ?, ?, ?)"))
            {
                command.Parameters.Add("@Broj", OleDbType.VarChar, 10).Value = kartica.Broj;
                command.Parameters.Add("@VlasnikID", OleDbType.Integer).Value = kartica.VlasnikId;
                command.Parameters.Add("@Ugovor", OleDbType.VarChar, 255).Value = kartica.Ugovor ?? (object)DBNull.Value;
                command.Parameters.Add("@Datum", OleDbType.Date).Value = kartica.Datum;
                command.Parameters.Add("@Aktivnost", OleDbType.Boolean).Value = kartica.Aktivnost;
                command.Parameters.Add("@OdgovornaOsoba", OleDbType.VarChar, 254).Value = kartica.OdgovornaOsoba ?? (object)DBNull.Value;

                ExecuteNonQuery(command);
            }
        }

        public void ObrisiKarticu(Kartica kartica)
        {
            using (OleDbCommand command = new OleDbCommand("DELETE FROM Kartice WHERE Broj = ?"))
            {
                command.Parameters.Add("@Broj", OleDbType.VarChar).Value = kartica.Broj;
                ExecuteNonQuery(command);
            }
        }

        public IList<Kartica> DajKarticeKorisnika(int korisnikId)
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
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

        public bool PostojiBrojKartice(string brojKartice, bool aktivnost)
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                OleDbCommand command = new OleDbCommand("SELECT COUNT(*) FROM Kartice WHERE Broj = ?" + (aktivnost ? " AND Aktivnost = True" : ""), connection);
                command.Parameters.Add("@Broj", OleDbType.VarChar).Value = brojKartice;
                
                try
                {
                    connection.Open();
                    return  (int)command.ExecuteScalar() > 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public override Type ObjectType
        {
            get { return typeof (Kartica); }
        }
    }
}
