using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace zooproject.Pages.Customer_Section
{
    public class AccountModel : PageModel
    {
        IConfiguration _config;
        Database database;
        string connection_string;

        public string AMessage = "";
        public string custID;
        public string updateCommand;
        public string selectCommand;

        public string selectFname;
        public string selectMname;
        public string selectLname;
        public string selectStreetAddress;
        public string selectCityAddress;
        public string selectZipAddress;
        public string selectStateAddress;
        public string selectPhone;
        public string selectEmail;
        public string selectMembership;
        public string selectExpiration;

        public AccountModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public void OnGet()
        {
            AMessage = "get";
            custID = HttpContext.User.Identity.Name;
            SelectInfo();
        }

        public void OnPost()
        {
            AMessage = "post";
            custID = HttpContext.User.Identity.Name;

            string inputFname = Request.Form["Fname"];
            string inputMname = Request.Form["Mname"];
            string inputLname = Request.Form["Lname"];
            string inputStreetAddress = Request.Form["StreetAddress"];
            string inputCityAddress = Request.Form["CityAddress"];
            string inputZipAddress = Request.Form["ZipAddress"];
            string inputStateAddress = Request.Form["StateAddress"];
            string inputPhone = Request.Form["Phone"];
            string inputEmail = Request.Form["Email"];

            database.connect();
            SqlCommand updatecmd = new SqlCommand();

            updatecmd.Connection = database.Connection;
            updateCommand = "UPDATE CUSTOMER SET Fname = '" +
                inputFname + "', Mname = '" + inputMname + "', Lname = '" +
                inputLname + "', StreetAddress = '" + inputStreetAddress +
                "', CityAddress = '" + inputCityAddress + "', ZipAddress = " +
                inputZipAddress + ", StateAddress = '" + inputStateAddress +
                "', Phone = " + inputPhone + ", Email = '" + inputEmail +
                "' WHERE ID = " + custID + ";";


            updatecmd.CommandText = updateCommand;

            try
            {
                updatecmd.ExecuteNonQuery();
            }
            catch(Exception e){
                AMessage = e.ToString();
            }
            updatecmd.Dispose();
            database.disconnect();

            SelectInfo();
        }
        
        public void SelectInfo()
        {
            database.connect();

            selectCommand = "SELECT * FROM CUSTOMER WHERE ID = " + custID;

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.Connection = database.Connection;
            selectcmd.CommandText = selectCommand;

            try
            {
                SqlDataReader reader = selectcmd.ExecuteReader();

                while (reader.Read())
                {
                    selectFname = reader.GetValue(1).ToString();
                    selectMname = reader.GetValue(2).ToString();
                    selectLname = reader.GetValue(3).ToString();
                    selectStreetAddress = reader.GetValue(4).ToString();
                    selectCityAddress = reader.GetValue(5).ToString();
                    selectZipAddress = reader.GetValue(6).ToString();
                    selectStateAddress = reader.GetValue(7).ToString();
                    selectPhone = reader.GetValue(8).ToString();
                    selectEmail = reader.GetValue(9).ToString();
                    selectMembership = reader.GetValue(10).ToString();
                    selectExpiration = reader.GetValue(11).ToString();
                }
                reader.Close();
            }
            catch(Exception e)
            {
                AMessage = e.ToString();
            }

            

            selectCommand = "SELECT Name FROM MEMBERSHIP_TYPE WHERE ID = " + selectMembership;
            selectcmd.CommandText = selectCommand;

            try
            {
                SqlDataReader reader2 = selectcmd.ExecuteReader();
                while (reader2.Read())
                    selectMembership = reader2.GetValue(0).ToString();

                reader2.Close();
            }
            catch(Exception e)
            {
                AMessage = e.ToString();
            }

            selectcmd.Dispose();
            database.disconnect();
        }
    }
}

