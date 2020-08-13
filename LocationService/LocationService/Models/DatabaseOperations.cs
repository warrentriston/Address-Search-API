using LocationService.Entities;
using LocationService.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LocationService.Models
{
    public class DatabaseOperations: IDataBaseAccess
    {
        static MySqlConnection dbConnection = new MySqlConnection(ConfigurationManager.AppSettings["dbConnection"]);

        /// <summary>
        /// This method will add new records into the database
        /// </summary>
        /// <param name="addresses">List of locations</param>
        /// <returns></returns>
        public void setLocation(List <Location> addresses)
        {
            dbConnection.Open();
            foreach (Location location in addresses)
            {
                using (MySqlCommand cmdSetLocation = dbConnection.CreateCommand())
                {
                    cmdSetLocation.CommandText = "INSERT INTO tbl_location(Address, City, State, Zip) VALUES (@Address,@City,@State,@Zip)";
                    cmdSetLocation.Parameters.AddWithValue("@Address", location.address);
                    cmdSetLocation.Parameters.AddWithValue("@City", location.city);
                    cmdSetLocation.Parameters.AddWithValue("@State", location.state);
                    cmdSetLocation.Parameters.AddWithValue("@Zip", location.zip);
                    cmdSetLocation.ExecuteNonQuery();
                }
            }
            dbConnection.Close();
        }


        /// <summary>
        /// This method will retrieve records from the database based on filter text
        /// </summary>
        /// <param name="searchText">Text based on which the records will be filtered</param>
        /// <returns></returns>
        public List<Location> getLocation(string searchText)
        {
            dbConnection.Open();
            List<Location> addresses = new List<Location>();
            MySqlCommand cmdGetLocation = dbConnection.CreateCommand();
            cmdGetLocation.CommandText = $"Select * from tbl_locatiodn Where Address Like '%{searchText}%' or State Like '%{searchText}%' or City Like '%{searchText}%' ORDER BY Address";
            MySqlDataReader drGetLocation = cmdGetLocation.ExecuteReader();
            while(drGetLocation.Read())
            {
                Location location = new Location();
                location.address = drGetLocation.GetValue(0).ToString();
                location.city = drGetLocation.GetValue(1).ToString();
                location.state = drGetLocation.GetValue(2).ToString();
                location.zip = Convert.ToInt32(drGetLocation.GetValue(3));
                addresses.Add(location);
            };
            dbConnection.Close();
            return addresses;

        }
    }
}