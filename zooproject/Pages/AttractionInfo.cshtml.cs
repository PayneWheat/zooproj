
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

        public List<int> IDResults = new List<int>();
        public List<string> NameResults = new List<string>();
        public List<Boolean> OpenResults = new List<Boolean>();
        public List<DateTime> OpenDateResults = new List<DateTime>();
        public List<int> ManagerResults = new List<int>();
        public List<DateTime> ManagerDateResults = new List<DateTime>();
        public List<string> DescriptionResults = new List<string>();

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
            database.disconnect();
        }
    }
}
