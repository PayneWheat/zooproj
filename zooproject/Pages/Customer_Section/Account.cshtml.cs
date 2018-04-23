using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            custID = HttpContext.User.Identity.Name;
            SelectInfo();
        }

        public void OnPost()
        {
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

            updateCommand = "UPDATE CUSTOMER SET Fname=@fname, Mname=@mname, Lname=@lname, StreetAddress=@address, CityAddress=@city, ZipAddress=@zip, StateAddress=@state, Phone=@phone, Email=@email WHERE Fname=@id";
            updatecmd.CommandText = updateCommand;

            updatecmd.Parameters.Add("@fname", System.Data.SqlDbType.VarChar);
            updatecmd.Parameters.Add("@mname", System.Data.SqlDbType.VarChar);
            updatecmd.Parameters.Add("@lname", System.Data.SqlDbType.VarChar);
            updatecmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar);
            updatecmd.Parameters.Add("@city", System.Data.SqlDbType.VarChar);
            updatecmd.Parameters.Add("@zip", System.Data.SqlDbType.Int);
            updatecmd.Parameters.Add("@state", System.Data.SqlDbType.VarChar);
            updatecmd.Parameters.Add("@phone", System.Data.SqlDbType.BigInt);
            updatecmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            updatecmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar);

            updatecmd.Parameters["@fname"].Value = inputFname;
            updatecmd.Parameters["@mname"].Value = inputMname;
            updatecmd.Parameters["@lname"].Value = inputLname;
            updatecmd.Parameters["@address"].Value = inputStreetAddress;
            updatecmd.Parameters["@city"].Value = inputCityAddress;
            updatecmd.Parameters["@zip"].Value = inputZipAddress;
            updatecmd.Parameters["@state"].Value = inputStateAddress;
            updatecmd.Parameters["@phone"].Value = inputPhone;
            updatecmd.Parameters["@email"].Value = inputEmail;
            updatecmd.Parameters["@id"].Value = custID;


            

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

            selectCommand = "SELECT * FROM CUSTOMER WHERE Fname=@name";

            SqlCommand selectcmd = new SqlCommand();
            selectcmd.Connection = database.Connection;
            selectcmd.CommandText = selectCommand;
            selectcmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
            selectcmd.Parameters["@name"].Value = custID;

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

