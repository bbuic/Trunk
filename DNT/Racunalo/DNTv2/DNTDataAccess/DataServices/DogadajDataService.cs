using System;
using System.Data.OleDb;
using DNTv2.DataAccess.Services;

namespace DNTDataAccess.DataServices
{
    public class DogadajDataService:AbstractAutoDataService
    {
        public void OtvoriDogadaj(DogadajTip dogadajTip, string kartica)
        {
            using (OleDbConnection connection = new OleDbConnection(Utils.ReadSetting("ConnectionString")))
            {
                Dogadaj dogadaj = new Dogadaj{DatumOd = DateTime.Now, DogadajTipId = dogadajTip};
                OleDbCommand command =
                    new OleDbCommand("INSERT INTO Dogadaj (DogadajTipID, DatumOd, Kartica) Values (?, ?, ?)", connection);

                command.Parameters.Add("", OleDbType.Integer).Value = dogadaj.DogadajTipId;
                command.Parameters.Add("", OleDbType.Date).Value = dogadaj.DatumOd;
                command.Parameters.Add("", OleDbType.VarChar).Value = string.IsNullOrEmpty(kartica) ? (object) DBNull.Value : kartica;

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

        public override Type ObjectType
        {
            get { return typeof (Dogadaj); }
        }
    }
}
