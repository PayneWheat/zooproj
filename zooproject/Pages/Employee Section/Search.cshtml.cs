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
                //Adds all IDs and Titles to Model.listname
                if (whichWhere == "")
                {
                    cmd.CommandText = "SELECT @attributes FROM @entity;";
                    cmd.Connection = database.Connection;
                    cmd.Parameters.AddWithValue("@attributes", whichAttributes);
                    string entityValue = "[dbo].[" + whichEntity + "]";
                    cmd.Parameters.AddWithValue("@entity", entityValue);
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM TITLE_TYPE";
                    cmd.Connection = database.Connection;
                }
                //cmd.Parameters.AddWithValue("@entity", whichEntity);
                //cmd.Parameters.AddWithValue("@att", whichAttributes);
                //cmd.Parameters.AddWithValue("@where", whichWhere);
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