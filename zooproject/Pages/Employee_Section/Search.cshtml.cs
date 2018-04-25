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

        public string successMessage = "";
        public SearchModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;
        }


        public void OnGet(string we = "", string wa = "", string av = "", int id = -1, bool update = false, bool insert = false)
        {

            if (update)
            {
                successMessage = "Entry successfully updated.";
            }
            else if(insert)
            {
                successMessage = "New entry created.";
            }
            Debug.WriteLine("Got");
            if (we != "")
            {
                database.connect();
                SqlCommand cmd = new SqlCommand();
                string joinClause = "";
                string selectClause = "";
                string fromClause = "";
                    // only entity value set
                whichEntity = we;
                if (whichEntity == "ANIMAL")
                {
                    //dbCommand = "SELECT ANIMAL.*, ATTRACTION.Name AttractionName FROM ANIMAL LEFT JOIN ATTRACTION ON Animal.Attraction = ATTRACTION.ID";
                    selectClause = "SELECT ANIMAL.ID, ANIMAL.Name, ANIMAL.Species, ANIMAL.Taxology, ATTRACTION.Name 'Attraction', ANIMAL.[Birth Location], ANIMAL.[Birth Date], ANIMAL.Gender, ANIMAL.Health, ANIMAL.Health_date 'Health status set' ";
                    fromClause = "FROM ANIMAL ";
                    joinClause = "LEFT JOIN ATTRACTION ON Animal.Attraction = ATTRACTION.ID";
                }
                else if (whichEntity == "ATTRACTION")
                {
                    //dbCommand = "SELECT ATTRACTION.*, EMPLOYEE.LName ManagerLastName FROM ATTRACTION LEFT JOIN EMPLOYEE ON ATTRACTION.Manager = EMPLOYEE.ID";
                    selectClause = "SELECT ATTRACTION.ID, ATTRACTION.Name, ATTRACTION.Open_closed 'Open status', ATTRACTION.Open_closed_date 'Date open/closed', EMPLOYEE.LName 'Manager Last Name', ATTRACTION.Manager_date 'Manager Date', ATTRACTION.Description ";
                    fromClause = "FROM ATTRACTION ";
                    joinClause = "LEFT JOIN EMPLOYEE ON ATTRACTION.Manager = EMPLOYEE.ID";
                }
                else if (whichEntity == "EMPLOYEE")
                {
                    /*
                   dbCommand = @"SELECT EMPLOYEE.*, GENDER_TYPE.Name 'Employee Gender', STORE.Name 'Store', ATTRACTION.Name 'Attraction' 
FROM EMPLOYEE
LEFT JOIN GENDER_TYPE ON EMPLOYEE.Gender = GENDER_TYPE.ID
LEFT JOIN STORE ON EMPLOYEE.Store = STORE.ID
LEFT JOIN ATTRACTION ON EMPLOYEE.Attraction = ATTRACTION.ID";
                    */
                    selectClause = "SELECT EMPLOYEE.ID, EMPLOYEE.Fname 'First Name', EMPLOYEE.Lname 'Last Name', TITLE_TYPE.Title 'Title', GENDER_TYPE.Name 'Gender', EMPLOYEE.Email, EMPLOYEE.Phone# 'Phone', EMPLOYEE.Hire_Date 'Date Hired', STORE.Name 'Store', ATTRACTION.Name 'Attraction', EMPLOYEE.Street, EMPLOYEE.City, EMPLOYEE.Zip, EMPLOYEE.State ";
                    fromClause = "FROM EMPLOYEE ";
                    joinClause = "LEFT JOIN GENDER_TYPE ON EMPLOYEE.Gender = GENDER_TYPE.ID";
                    joinClause += " LEFT JOIN STORE ON EMPLOYEE.Store = STORE.ID";
                    joinClause += " LEFT JOIN ATTRACTION ON EMPLOYEE.Attraction = ATTRACTION.ID";
                    joinClause += " LEFT JOIN TITLE_TYPE ON EMPLOYEE.Title = TITLE_TYPE.ID";
                }
                else if (whichEntity == "CUSTOMER")
                {
                    //dbCommand = "SELECT CUSTOMER.*, MEMBERSHIP_TYPE.Name MembershipTypeName FROM CUSTOMER LEFT JOIN MEMBERSHIP_TYPE ON CUSTOMER.MembershipType= MEMBERSHIP_TYPE.ID";
                    selectClause = "SELECT CUSTOMER.ID, CUSTOMER.Fname 'First Name', CUSTOMER.Lname 'Last Name', CUSTOMER.StreetAddress 'Address', CUSTOMER.CityAddress 'City', CUSTOMER.StateAddress 'State', CUSTOMER.Phone, CUSTOMER.Email, MEMBERSHIP_TYPE.Name 'Membership Type', CUSTOMER.ExpirationDate 'Membership Expiration' ";
                    fromClause = "FROM CUSTOMER ";
                    joinClause = "LEFT JOIN MEMBERSHIP_TYPE ON CUSTOMER.MembershipType= MEMBERSHIP_TYPE.ID";
                }
                else if (whichEntity == "PURCHASE")
                {
                    /*
                    dbCommand = @"SELECT PURCHASE.*, PAY_TYPE.Name 'Payment Type', STORE.Name 'Store Name', CUSTOMER.Lname 'Customer Last Name', EMPLOYEE.Lname 'Employee Last Name'
FROM PURCHASE
LEFT JOIN PAY_TYPE ON PURCHASE.Pay_option = PAY_TYPE.ID
LEFT JOIN STORE ON PURCHASE.Store = STORE.ID
LEFT JOIN CUSTOMER ON PURCHASE.Customer = CUSTOMER.ID
LEFT JOIN EMPLOYEE ON PURCHASE.Employee = EMPLOYEE.ID";
*/
                    selectClause = "SELECT PURCHASE.Receipt, PURCHASE.Date, PURCHASE.Time, PAY_TYPE.Name 'Payment Type', STORE.Name 'Store Name', CUSTOMER.Lname 'Customer Last Name', EMPLOYEE.Lname 'Employee Last Name' ";
                    fromClause = "FROM PURCHASE ";
                    joinClause = "LEFT JOIN PAY_TYPE ON PURCHASE.Pay_option = PAY_TYPE.ID";
                    joinClause += " LEFT JOIN STORE ON PURCHASE.Store = STORE.ID";
                    joinClause += " LEFT JOIN CUSTOMER ON PURCHASE.Customer = CUSTOMER.ID";
                    joinClause += " LEFT JOIN EMPLOYEE ON PURCHASE.Employee = EMPLOYEE.ID";
                }
                else if (whichEntity == "PURCHASE_INFO")
                {
                    //dbCommand = "SELECT PURCHASE_INFO.*, PRODUCT.Name ProductName FROM PURCHASE_INFO LEFT JOIN PRODUCT ON PURCHASE_INFO.Product = PRODUCT.ID";
                    selectClause = "SELECT PURCHASE_INFO.Receipt, PRODUCT.Name 'Product', PURCHASE_INFO.Price, PURCHASE_INFO.Quantity ";
                    fromClause = "FROM PURCHASE_INFO ";
                    joinClause = "LEFT JOIN PRODUCT ON PURCHASE_INFO.Product = PRODUCT.ID";
                }
                else if (whichEntity == "STORE")
                {
                    //dbCommand = "SELECT STORE.*, EMPLOYEE.LName Manager FROM STORE LEFT JOIN EMPLOYEE ON STORE.Manager = EMPLOYEE.ID";
                    selectClause = "SELECT STORE.ID, STORE.Name, STORE_TYPE.Name 'Store Type', EMPLOYEE.LName Manager, STORE.Manager_date 'Manager Date' ";
                    fromClause = "FROM STORE ";
                    joinClause = "LEFT JOIN EMPLOYEE ON STORE.Manager = EMPLOYEE.ID";
                    joinClause += " LEFT JOIN STORE_TYPE ON STORE.Type = STORE_TYPE.ID";
                }
                else
                {
                    //dbCommand = "SELECT * FROM " + whichEntity + ";";
                    selectClause = "SELECT * ";
                    fromClause = "FROM " + whichEntity;
                }

                string whereClause = "";
                if (wa == "" && id != -1)
                {
                    // entity and id are set, no attributes
                    whichEntity = we;
                    whichID = id.ToString();
                    // PURCHASE table, PURCHASE info: ID = Receipt
                    if (whichEntity == "PURCHASE" || whichEntity == "PURCHASE_INFO")
                    {
                        //dbCommand = "SELECT * FROM " + whichEntity + " WHERE Receipt=" + id + ";";
                        whereClause = "WHERE Receipt=" + id + " ";
                    }
                    else
                    {
                        //dbCommand = "SELECT * FROM " + whichEntity + " WHERE ID=" + id + ";";
                        whereClause = "WHERE ID=" + id + " ";
                    }

                }
                else if (wa != "" && av != "" && id == -1)
                {
                    // entity and attribute value set, no id
                    whichEntity = we;
                    whichAttributes = wa;
                    whichWhere = av;
                    //dbCommand = "SELECT FROM " + whichEntity + " WHERE " + wa + "=" + av + ";";
                    whereClause = "WHERE " + wa + "=" + av + " ";
                }
                dbCommand = selectClause + fromClause + whereClause + joinClause + ";";
                Debug.WriteLine(dbCommand);
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
                    for (int i = 0; i < AInt; i++)
                    {
                        Results[j].Add(reader[i].ToString());
                    }
                    j++;
                }
                BInt = j;
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