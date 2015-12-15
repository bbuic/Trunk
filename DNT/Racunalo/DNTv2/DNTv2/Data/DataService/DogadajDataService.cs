using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using DNTDataAccess;
using DNTv2.DataModel;

namespace DNTv2.Data.DataService
{
    public class DogadajDataService : DNTDataAccess.DataServices.DogadajDataService
    {
        public IList<DogadajModel> DajSveDogadaje()
        {
            using (OleDbConnection connection = new OleDbConnection(DNTDataAccess.Utils.ReadSetting("ConnectionString")))
            {
                DataTable table = new DataTable();
                OleDbCommand command = new OleDbCommand("SELECT DogadajTipId, DatumOd, DatumDo, Kartica, Ime, Prezime FROM " +
                                                        "(Dogadaj d LEFT JOIN Kartice ka ON ka.Broj = d.Kartica) " +
                                                        "LEFT JOIN DNTKorisnici ko ON ka.VlasnikID = ko.ID " +
                                                        "WHERE DatumDo IS NULL", connection);
                try
                {
                    connection.Open();
                    new OleDbDataAdapter(command).Fill(table);
                }
                finally
                {
                    connection.Close();
                }

                IList<DogadajModel> list = ToList<DogadajModel>(GetArrayList(table));                
                return list;
            }
        }

        public override Type ObjectType
        {
            get { return typeof (DogadajModel); }
        }
    }
}
