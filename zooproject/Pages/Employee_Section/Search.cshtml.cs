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

        public SqlDataReader reader;

        public List<List<string>> Results = new List<List<string>>();
        public List<string> ColumnNames = new List<string>();

        public string whichEntity = "";
        public string whichAttributes = "";
        public string whichWhere = "";
        public string whichOther = "";

        public string dbCommand = "";

        public string AMessage = "";
        public int AInt = 20;

        public SearchModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

            for (int i = 0; i < 30; i++)
                Results.Add(new List<string>());
        }


        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            whichEntity = Request.Form["entityType"];
            whichAttributes = Request.Form["attributeType"];
            whichWhere = Request.Form["whereType"];
            whichOther = Request.Form["otherType"];

            if(whichEntity != "" && whichAttributes != "")
            {
                database.connect();

                SqlCommand cmd = new SqlCommand();

                if (whichWhere == "")
                {
                    dbCommand = "SELECT " + whichAttributes + " FROM "+
                        whichEntity + " " + whichOther + ";";

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

                reader = cmd.ExecuteReader();

                int j = 0;
                while (reader.Read())
                {
                    AInt = reader.FieldCount;
                    //AMessage = reader.GetValue(1).ToString();
                    for(; j < AInt; j++)
                    {
                        ColumnNames.Add(reader.GetName(j));
                    }

                    for (int i = 0; i < AInt; i++)
                    {   
                        if(reader.IsDBNull(i) == false)
                            Results[i].Add(reader.GetValue(i).ToString());
                        else
                        {
                            Results[i].Add("NULL");
                        }
                    }
                }

                // Cleanup
                reader.Close();
                cmd.Dispose();
                database.disconnect();
            }
        }
    }
}