using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace zooproject.Pages.Employee_Section
{
    public class SearchModel : PageModel
    {
        IConfiguration _config;
        Database database;
        string connection_string;

        public List<string> TypeResults = new List<string>();
        public List<int> IDResults = new List<int>();

        public string whichEntity = "";
        public string whichAttributes = "";
        public string whichWhere = "";

        public string dbCommand = "";

        public SearchModel(IConfiguration iconfiguration, Database ZooDatabase)
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
            whichEntity = Request.Form["entityType"];
            whichAttributes = Request.Form["attributeType"];
            whichWhere = Request.Form["whereType"];

            if(whichEntity != "" && whichAttributes != "")
            {
                database.connect();

                SqlCommand cmd = new SqlCommand();

                if (whichWhere == "")
                {
                    dbCommand = "SELECT " + whichAttributes + " FROM [dbo].[" +
                        whichEntity + "];";

                    cmd.CommandText = dbCommand;
                    cmd.Connection = database.Connection;
                }
                else
                {
                    dbCommand = "SELECT " + whichAttributes + " FROM [dbo].[" +
                        whichEntity + "] WHERE " + whichWhere + ";";
                    cmd.CommandText = dbCommand;
                    cmd.Connection = database.Connection;
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    IDResults.Add(reader.GetInt32(0));
                    TypeResults.Add(reader.GetString(1));
                }

                // Cleanup
                reader.Close();
                cmd.Dispose();
                database.disconnect();
            }
        }
    }
}