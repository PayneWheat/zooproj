using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace zooproject.Pages.Employee_Section
{
    public class InsertModel : PageModel
    {
        IConfiguration _config;
        Database database;
        string connection_string;

        public SqlDataReader reader;
        public SqlDataAdapter adapter;

        public string AMessage = "";
        public string EMessage = "";
        public string whichEntity = "";
        public string dbCommand = "";

        public InsertModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public void OnGet()
        {   
        }

        public void OnPost()
        {
            AMessage = "posted";
            whichEntity = Request.Form["entityType"];

            if (whichEntity == "TITLE_TYPE")
            {
                AMessage = "controller recognized TITLE_TYPE";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertType = Request.Form["insertType"];

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Title) " +
                    "VALUES(" + insertID + ", '" + insertType + "');";
                
                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                }

                catch(SqlException e)
                {
                    EMessage = "Failed to execute insert";
                }
                
                cmd.Dispose();
                database.disconnect();
            }

            if (whichEntity == "ATTRACTION")
            {
                AMessage = "controller recogznied ATTRACTION";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertType = Request.Form["insertType"];
                string insertOpen = Request.Form["insertOpen"];
                string insertOpenDate = Request.Form["insertOpenDate"];
                string insertManager = Request.Form["insertManager"];
                string insertManagerDate = Request.Form["insertManagerDate"];
                string insertDescription = Request.Form["insertDescription"];

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Name, Open_closed, " +
                    "Open_closed_date, Manager, Manager_date, Description) " +
                    "VALUES(" + insertID + ", '" + insertType + "', " + insertOpen +
                     ", '" + insertOpenDate + "', " + insertManager + ", '" + 
                     insertManagerDate + "', '" + insertDescription + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert";
                }

                cmd.Dispose();
                database.disconnect();
            }

            if(whichEntity == "PRODUCT")
            {
                AMessage = "controller recogznied PRODUCT";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertType = Request.Form["insertType"];
                string insertPrice = Request.Form["insertPrice"];
                string insertDescription = Request.Form["insertDescription"];

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Name, Price, Description) " +
                    "VALUES(" + insertID + ", '" + insertType + "', " + insertPrice +
                     ", '" + insertDescription + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert";
                }

                cmd.Dispose();
                database.disconnect();
            }

            if (whichEntity == "EMPLOYEE")
            {
                AMessage = "controller recogznied EMPLOYEE";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertFname = Request.Form["insertFname"];
                string insertMname = Request.Form["insertMname"];
                string insertLname = Request.Form["insertLname"];
                string insertTitle = Request.Form["insertTitle"];
                string insertHire_Date = Request.Form["insertHire_Date"];
                string insertStreet = Request.Form["insertStreet"];
                string insertCity = Request.Form["insertCity"];
                string insertZip = Request.Form["insertZip"];
                string insertState = Request.Form["insertState"];
                string insertEmail = Request.Form["insertEmail"];
                string insertPhone = Request.Form["insertPhone#"];
                string insertGender = Request.Form["insertGender"];
                string insertStore = Request.Form["insertStore"];
                string insertAttraction = Request.Form["insertAttraction"];

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Fname, Mname, Lname, [Title]," +
                    " Hire_Date, Street, City, Zip, [State], Email, Phone#, Gender, Store, Attraction) " +
                    "VALUES(" + insertID + ", '" + insertFname + "', '" + insertMname +
                     "', '" + insertLname + "', " + insertTitle + ", '" + insertHire_Date + 
                     "', '" + insertStreet + "', '" + insertCity + "', '" + insertZip + "', '" + 
                     insertState + "', '" + insertEmail + "', " + insertPhone + ", " + insertGender + 
                     ", " + insertStore + ", " + insertAttraction + ");";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert";
                }

                cmd.Dispose();
                database.disconnect();
            }
        }
        
    }
}