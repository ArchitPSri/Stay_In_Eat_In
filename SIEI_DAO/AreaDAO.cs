using System;
using SIEI_AreaEntites;
using DBConnection;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SIEI_AreaDAO
{
    public class AreaDAO
    {
        public AreaDAO()
        { }

        // Get area list
        public List<AreaList> GetAreaList(string areaOf)
        {
            List<AreaList> areaLists = new List<AreaList>();
            try
            {
                DBConnectionClass dBConnection = new DBConnectionClass
                {
                    DatabaseName = "StayInEatIn"
                };

                string Col_Area = areaOf;

                if (dBConnection.IsConnect())
                {
                    var cmd = new SqlCommand("SIEI_AREA_GetAreaList", dBConnection.Connection);
                    cmd.Parameters.AddWithValue("@Col_Area", Col_Area);

                    SqlDataAdapter reader = new SqlDataAdapter(cmd);
                    if (reader != null)
                    {
                        DataTable dt = new DataTable();
                        reader.Fill(dt);

                        foreach (DataRow areas in dt.Rows)
                        {
                            AreaList d = new AreaList();
                            d.Area = (string)areas["Area"];
                            areaLists.Add(d);
                        }
                        return areaLists;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Empty Reader");
                    }

                    dBConnection.Close();
                    return null;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Conn Failed");
                    return null;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Unsuccessful Query Excution");
                throw e;
            }
            finally
            {

            }
        }
    }
}
