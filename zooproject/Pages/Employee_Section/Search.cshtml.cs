using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

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
        public string whichID = "";

        public string dbCommand = "";

        public string AMessage = "";
        public int AInt = 0;
        public int BInt = 0;

        public SearchModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

            for (int i = 0; i < 30; i++)
                Results.Add(new List<string>());
        }


        public void OnGet(string we = "", string wa = "", string av = "", int id = -1)
        {
            if (we != "")
            {
                database.connect();
                SqlCommand cmd = new SqlCommand();
                if (we != "" && wa == "" && id == -1)
                {
                    // only entity value set
                    whichEntity = we;
                    dbCommand = "SELECT * FROM " + whichEntity + ";";
                }
                else if (we != "" && wa != "" && av != "" && id == -1)
                {
                    // entity and attribute value set, no id
                    whichEntity = we;
                    whichAttributes = wa;
                    whichWhere = av;
                    dbCommand = "SELECT FROM " + whichEntity + " WHERE " + wa + "=" + av + ";";
                }
                else if (we != "" && wa == "" && id != -1)
                {
                    // entity and id are set, no attributes
                    whichEntity = we;
                    whichID = id.ToString();
                    // PURCHASE table, PURCHASE info: ID = Receipt
                    if (whichEntity == "PURCHASE" || whichEntity == "PURCHASE_INFO")
                    {
                        dbCommand = "SELECT * FROM " + whichEntity + " WHERE Receipt=" + id + ";";
                    }
                    else
                    {
                        dbCommand = "SELECT * FROM " + whichEntity + " WHERE ID=" + id + ";";
                    }

                }
                cmd.Connection = database.Connection;
                cmd.CommandText = dbCommand;
                reader = cmd.ExecuteReader();
                AInt = reader.FieldCount;
                for (int i = 0; i < AInt; i++)
                {
                    ColumnNames.Add(reader.GetName(i));
                }

                int j = 0;
                while (reader.Read())
                {
                    Results.Add(new List<string>());
                    Debug.WriteLine("New list appended to results list");
                    for (int i = 0; i < AInt; i++)
                    {
                        Results[j].Add(reader[i].ToString());
                    }
                    Debug.WriteLine("List completed. Should have " + AInt + " entries: " + Results[j].Count());
                    j++;
                }
                BInt = j;
                Debug.WriteLine("Results count: " + Results.Count() + "; AInt: " + AInt);
                database.disconnect();
                cmd.Dispose();
            }
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