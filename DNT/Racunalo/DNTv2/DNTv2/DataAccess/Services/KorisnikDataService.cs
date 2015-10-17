using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using DNTv2.DataModel;
using DNTv2.DataModel.DataServices;

namespace DNTv2.DataAccess.Services
{
    public class KorisnikDataService : AbstractAutoDataService
    {
        public IList<Korisnik> DajSveKorisnike()
        {
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionString))
            {
                DataTable table = new DataTable();
                OleDbCommand command = new OleDbCommand("SELECT * FROM DNTKorisnici ORDER BY ime, prezime", connection);
                try
                {
                    connection.Open();
                    new OleDbDataAdapter(command).Fill(table);
                }
                finally
                {
                    connection.Close();
                }

                return ToList<Korisnik>(GetArrayList(table));
            }
        }
        
        public override Type ObjectType
        {
            get { return typeof(Korisnik); }
        }
    }
}
