
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace zooproject.Pages
{
    public class AttractionInfoModel : PageModel
    {
        public string errorMessage { get; set; }
        public int Aint = 0;

        public List<int> IDResults = new List<int>();
        public List<string> NameResults = new List<string>();
        public List<Boolean> OpenResults = new List<Boolean>();
        public List<DateTime> OpenDateResults = new List<DateTime>();
        public List<int> ManagerResults = new List<int>();
        public List<DateTime> ManagerDateResults = new List<DateTime>();
        public List<string> DescriptionResults = new List<string>();

        public string AttractionChoice = "";
        public List<string> AnimalList = new List<string>();
        public string dbCommand;

        IConfiguration _config;
        Database database;
        string connection_string;

        public AttractionInfoModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public void OnGet()
        {
            // Connect to database 
            database.connect();

            //Adds all IDs and Titles to Model.listname
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[ATTRACTION]", 
                database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                IDResults.Add(reader.GetInt32(0));
                NameResults.Add(reader.GetString(1));
                OpenResults.Add(reader.GetBoolean(2));
                OpenDateResults.Add(reader.GetDateTime(3));
                ManagerResults.Add(reader.GetInt32(4));
                ManagerDateResults.Add(reader.GetDateTime(5));
                DescriptionResults.Add(reader.GetString(6));
            }

            // Cleanup
            reader.Close();
            cmd.Dispose();

            AttractionChoice = Request.Query["Animals"];

            if (AttractionChoice != "")
            {
                dbCommand = "SELECT DISTINCT Species FROM [dbo].[ANIMAL] WHERE [Attraction] = " + AttractionChoice;
                
                try
                {
                    SqlCommand cmd2 = new SqlCommand(dbCommand, database.Connection);
                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        Aint = reader2.FieldCount;
                        AnimalList.Add(reader2.GetValue(0).ToString());
                    }
                    reader2.Close();
                    cmd2.Dispose();
                }
                catch (SqlException e)
                {
                    errorMessage = e.ToString();
                }
                database.disconnect();
            }

        }
    }
}
