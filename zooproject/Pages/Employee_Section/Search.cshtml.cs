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
        public List<List<string>> Results2 = new List<List<string>>();
        public List<List<string>> Results3 = new List<List<string>>();
        public List<List<string>> Results4 = new List<List<string>>();
        public List<List<string>> Results5 = new List<List<string>>();
        public List<List<string>> ResultsHidden = new List<List<string>>();
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
        public int CInt = 0;
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
            Debug.WriteLine("Got");
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
                    //Debug.WriteLine("New list appended to results list");
                    for (int i = 0; i < AInt; i++)
                    {
                        Results[j].Add(reader[i].ToString());
                    }
                    //Debug.WriteLine("List completed. Should have " + AInt + " entries: " + Results[j].Count());
                    j++;
                }
                BInt = j;
                //Debug.WriteLine("Results count: " + Results.Count() + "; AInt: " + AInt);
                database.disconnect();
                cmd.Dispose();

                // load secondary results for drop down menus
                if (we == "ANIMAL")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM ATTRACTION;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            //Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();

                }
                if (we == "ATTRACTION")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, LName FROM EMPLOYEE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();

                }
                else if (we == "CUSTOMER")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM MEMBERSHIP_TYPE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                }
                else if (we == "EMPLOYEE")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM ATTRACTION;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM STORE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        Results3.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results3[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Title FROM TITLE_TYPE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        Results4.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results4[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM GENDER_TYPE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        Results5.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results5[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                }
                else if (we == "PURCHASE")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM PAY_TYPE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM STORE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        Results3.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results3[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();

                }
                else if (we == "STORE")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, LName FROM EMPLOYEE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                }
            }
        }

        public void OnPost(string we = "")
        {

            if (we != "")
            {
                Debug.WriteLine("Posted");
                whichEntity = we;

                /*
                whichEntity = Request.Form["entityType"];
                whichAttributes = Request.Form["attributeType"];
                whichWhere = Request.Form["whereType"];
                whichOther = Request.Form["otherType"];
                */

                int j = 0;
                SqlCommand cmd = new SqlCommand();
                string whereClause = "";
                List<string> keyList = Request.Form.Keys.ToList();
                Debug.WriteLine("Beginning key traversal...");
                int nonEmptyCount = 0;
                for (int i = 0; i < keyList.Count() - 1; i++)
                {
                    Debug.Write(keyList[i] + ", ");

                    if (!string.IsNullOrEmpty(Request.Form[keyList[i]]))
                    {
                        if (nonEmptyCount < 1)
                            whereClause += "WHERE [" + keyList[i] + "]='" + Request.Form[keyList[i]] + "'";
                        else
                            whereClause += " AND [" + keyList[i] + "]='" + Request.Form[keyList[i]] + "'";
                        nonEmptyCount++;
                    }
                }
                Debug.WriteLine("whereClause: " + whereClause);
                dbCommand = "SELECT * FROM " + whichEntity + " " + whereClause + ";";
                Debug.WriteLine("dbCommand: " + dbCommand);
                database.connect();
                cmd = new SqlCommand();
                cmd.CommandText = dbCommand;
                cmd.Connection = database.Connection;
                reader = cmd.ExecuteReader();
                AInt = reader.FieldCount;
                Debug.WriteLine("AInt: " + AInt);
                j = 0;
                for (; j < AInt; j++)
                {
                    ColumnNames.Add(reader.GetName(j));
                }
                j = 0;
                while (reader.Read())
                {
                    Results.Add(new List<string>());
                    for (int i = 0; i < AInt; i++)
                    {
                        Debug.Write(reader[i].ToString() + " , ");
                        Results[j].Add(reader[i].ToString());
                    }
                    j++;
                }
                Debug.Write("\n");
                BInt = j;
                Debug.WriteLine("Column count:" + ColumnNames.Count() + " Results count: " + Results.Count() + " BInt/j: " + BInt);
                for (int i = 0; i < Results.Count(); i++)
                {
                    for (j = 0; j < Results[i].Count(); j++)
                    {
                        Debug.Write(Results[i][j]);
                    }
                }
                // Cleanup
                reader.Close();
                cmd.Dispose();
                database.disconnect();

                // pull in whole table to pass possible keys to autocomplete
                dbCommand = "SELECT * FROM " + we;
                database.connect();
                cmd.CommandText = dbCommand;
                cmd.Connection = database.Connection;
                reader = cmd.ExecuteReader();
                j = 0;
                while (reader.Read())
                {
                    ResultsHidden.Add(new List<string>());
                    for (int i = 0; i < AInt; i++)
                    {
                        Debug.Write(reader[i].ToString() + ", ");
                        ResultsHidden[j].Add(reader[i].ToString());
                    }
                    j++;
                }
                CInt = j;
                Debug.WriteLine("CInt: " + CInt);
                // Cleanup
                reader.Close();
                cmd.Dispose();
                database.disconnect();

                // load secondary results for drop down menus
                if (we == "ANIMAL")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM ATTRACTION;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            //Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                }


                if (we == "ATTRACTION")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, LName FROM EMPLOYEE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();

                }
                else if (we == "CUSTOMER")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM MEMBERSHIP_TYPE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                }
                else if (we == "EMPLOYEE")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM ATTRACTION;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM STORE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        Results3.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results3[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Title FROM TITLE_TYPE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        Results4.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results4[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                }
                else if (we == "PURCHASE")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM PAY_TYPE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, Name FROM STORE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        Results3.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results3[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                }
                else if (we == "STORE")
                {
                    database.connect();
                    cmd = new SqlCommand();
                    dbCommand = "SELECT ID, LName FROM EMPLOYEE;";
                    cmd.Connection = database.Connection;
                    cmd.CommandText = dbCommand;
                    reader = cmd.ExecuteReader();
                    int k = 0;
                    while (reader.Read())
                    {
                        Results2.Add(new List<string>());
                        for (int i = 0; i < 2; i++)
                        {
                            Debug.WriteLine(reader[i].ToString());
                            Results2[k].Add(reader[i].ToString());
                        }
                        k++;
                    }
                    database.disconnect();
                }
            }
        }
    }

}