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
    public class UpdateModel : PageModel
    {
        IConfiguration _config;
        Database database;
        string connection_string;
        public SqlDataReader reader;
        public string dbCommand;
        public string EMessage;
        public string whichEntity = "";
        public string whichAttributes = "";
        public string whichWhere = "";
        public int AInt = 0;
        public int BInt = 0;
        public List<List<string>> Results = new List<List<string>>();
        public List<string> ColumnNames = new List<string>();
        public string successMessage = "";

        public UpdateModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public void OnGet(string we = "", string wa = "", string av = "", int id = -1, bool success = true)
        {
            if (!success)
            {
                successMessage = "Failed to update entry!";
            }
            if(we != "" && id != -1)
            {
                whichEntity = we;
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

        public void OnPost(string we = "", int id = -1)
        {
            if (we != "" && id != -1)
            {
                whichEntity = we;
                Debug.WriteLine("we: " + we);
                
                string setClause = "";
                List<string> keyList = Request.Form.Keys.ToList();
                for(int i = 0; i < keyList.Count() - 1; i++)
                {
                    string val = Request.Form[keyList[i]];
                    Debug.WriteLine(keyList[i] + ": " + val);
                    if(String.IsNullOrEmpty(val))
                    {
                        val = "NULL";
                    }
                    else
                    {
                        val = "'" + val + "'";
                    }
                    if (i == 0)
                        setClause += keyList[i] + "=" + val;
                    else if (keyList[i] == "GENDER_TYPE")
                        setClause += ", [" + keyList[i] + "]=" + int.Parse(val);
                    else
                        setClause += ", [" + keyList[i] + "]=" + val;
                }
                Debug.WriteLine(setClause);
                //dbCommand = "UPDATE " + we + " SET " + setClause + " WHERE ID=" + id.ToString() + ";";
                if (whichEntity == "PURCHASE" || whichEntity == "PURCHASE_INFO")
                {
                    dbCommand = "UPDATE  " + whichEntity + " SET " + setClause + " WHERE Receipt=" + id.ToString() + ";";
                }
                else
                {
                    dbCommand = "UPDATE " + we + " SET " + setClause + " WHERE ID=" + id.ToString() + ";";
                }
                Debug.WriteLine(dbCommand);
                database.connect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = dbCommand;
                cmd.Connection = database.Connection;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "query successful";
                    Response.Redirect("./Search?we=" + whichEntity + "&update=true");
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute SqlQuery" + e.ToString();
                    Response.Redirect("./Update?we=" + whichEntity + "&success=false");
                }
                cmd.Dispose();
                database.disconnect();
            }
        }
    }
}