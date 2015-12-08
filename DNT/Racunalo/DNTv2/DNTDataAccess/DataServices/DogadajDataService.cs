using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using DNTv2.DataAccess.Services;

namespace DNTDataAccess.DataServices
{
    public class DogadajDataService:AbstractAutoDataService
    {
        public void OtvoriDogadaj(DogadajTip dogadajTip)
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                Dogadaj dogadaj = new Dogadaj{DatumOd = DateTime.Now, DogadajTipId = dogadajTip};
                OleDbCommand command =
                    new OleDbCommand("INSERT INTO Dogadaj (DogadajTipID, DatumOd) Values (?, ?)", connection);

                command.Parameters.Add("", OleDbType.Integer).Value = dogadaj.DogadajTipId;
                command.Parameters.Add("", OleDbType.Date).Value = dogadaj.DatumOd;

                ExecuteNonQuery(command);
            }
        }

        public void ZatvoriDogadaj(DogadajTip dogadajTip)
        {
            using (OleDbCommand command = new OleDbCommand("UPDATE Dogadaj SET DatumDo = ? WHERE DogadajTipId = ? AND DatumDo IS NULL"))
            {
                command.Parameters.Add("", OleDbType.Date).Value = DateTime.Now;
                command.Parameters.Add("", OleDbType.Integer).Value = dogadajTip;
                ExecuteNonQuery(command);                
            }
        }

        public IList<Dogadaj> DajSveDogadaje()
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                DataTable table = new DataTable();
                OleDbCommand command = new OleDbCommand("SELECT DogadajTipId, DatumOd, DatumDo FROM Dogadaj WHERE DatumDo IS NULL", connection);
                try
                {
                    connection.Open();
                    new OleDbDataAdapter(command).Fill(table);
                }
                finally
                {
                    connection.Close();
                }

                IList<Dogadaj> list = ToList<Dogadaj>(GetArrayList(table));                
                return list;
            }
        }

        public override Type ObjectType
        {
            get { return typeof (Dogadaj); }
        }
    }
}
