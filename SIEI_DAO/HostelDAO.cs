using System;
using SIEI_Entites;
using DBConnection;
using System.Data.SqlClient;

namespace SIEI_HostelDAO
{
    public class HostelDAO
    {
        public HostelDAO()
        { }

        // Save hostel details
        public void SaveHostelDetails(HostelDetails hostelDetails)
        {
            try
            {
                DBConnectionClass dBConnection = new DBConnectionClass
                {
                    DatabaseName = "StayInEatIn"
                };

                string Col_Name = hostelDetails.Name;
                string Col_Area = hostelDetails.Area;
                string Col_Address = hostelDetails.Address;
                string Col_City = hostelDetails.City;
                string Col_Pin = hostelDetails.Pin;
                string Col_Mobile1 = hostelDetails.Mobile1;
                string Col_Mobile2 = hostelDetails.Mobile2;
                string Col_RoomFor = hostelDetails.RoomFor;
                int Col_Type = hostelDetails.Type;
                int Col_Furnished = hostelDetails.Furnished;
                string Col_StartingPrice = hostelDetails.StartingPrice;
                int Col_FoodAvail = hostelDetails.FoodAvail;

                if (dBConnection.IsConnect())
                {
                    var cmd = new SqlCommand("SIEI_HOST_SaveHostelDetails", dBConnection.Connection);
                    cmd.Parameters.AddWithValue("@Col_Name", Col_Name);
                    cmd.Parameters.AddWithValue("@Col_Area", Col_Area);
                    cmd.Parameters.AddWithValue("@Col_Address", Col_Address);
                    cmd.Parameters.AddWithValue("@Col_City", Col_City);
                    cmd.Parameters.AddWithValue("@Col_Pin", Col_Pin);
                    cmd.Parameters.AddWithValue("@Col_Mobile1", Col_Mobile1);
                    cmd.Parameters.AddWithValue("@Col_Mobile2", Col_Mobile2);
                    cmd.Parameters.AddWithValue("@Col_RoomFor", Col_RoomFor);
                    cmd.Parameters.AddWithValue("@Col_Furnished", Col_Furnished);
                    cmd.Parameters.AddWithValue("@Col_StartingPrice", Col_StartingPrice);
                    cmd.Parameters.AddWithValue("@Col_FoodAvail", Col_FoodAvail);

                    string value = cmd.ExecuteNonQuery().ToString();

                    dBConnection.Close();
                    //return value;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Conn Failed");
                    //return null;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Unsuccessful Query Excution");
                throw e;
            }
        }
    }
}
