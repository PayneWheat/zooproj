using System;
using System.Data;
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
using System.Diagnostics;

namespace zooproject.Pages.Employee_Section
{
    public class InsertModel : PageModel
    {
        IConfiguration _config;
        Database database;
        string connection_string;

        public SqlDataReader reader;
        public SqlDataAdapter adapter;

        public string AMessage = "Loaded";
        public string EMessage = "";
        public string whichEntity = "";
        public string dbCommand = "";
        public List<List<string>> Results = new List<List<string>>();
        public List<string> ColumnNames = new List<string>();
        public List<List<string>> Results2 = new List<List<string>>();
        public List<string> ColumnNames2 = new List<string>();
        public int AInt { get; set; }
        public int BInt { get; set; }

        public InsertModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public void OnGet(string we= "")
        {
            AMessage = "got";
  
            if (we != "")
            {
                SqlCommand cmd = new SqlCommand();
                whichEntity = we;
                Debug.WriteLine("Entity: " + whichEntity);
                database.connect();
                dbCommand = "SELECT * FROM " + whichEntity;
                
                cmd.Connection = database.Connection;
                cmd.CommandText = dbCommand;
                reader = cmd.ExecuteReader();
                //IDataRecord record;
                AInt = reader.FieldCount;
                Debug.WriteLine(AInt.ToString());
                string output = "";
                for (int i = 0; i < AInt; i++)
                {
                    ColumnNames.Add(reader.GetName(i));
                    output += reader.GetName(i);
                }
                Debug.WriteLine(output);
                output = "";
                int j = 0;
                while (reader.Read())
                {
                    //Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                    Results.Add(new List<string>());
                    for (int i = 0; i < AInt; i++)
                    {
                        output += reader[i] + ", ";
                        Results[j].Add(reader[i].ToString());
                    }
                    j++;
                    output += '\n';
                }
                Debug.WriteLine("Results count: " + Results.Count());
                Debug.WriteLine(output);
                database.disconnect();
                cmd.Dispose();
            }
            if(we == "PURCHASE")
            {
                // load purchase_info and pay_type tables
                //dbCommand = "SELECT * FROM PURCHASE_INFO";
                // do some stuff
                //dbCommand = "SELECT * FROM PAY_TYPE";
                // do some stuff
            }
            else if(we == "PURCHASE_INFO")
            {
                SqlCommand cmd = new SqlCommand();
                database.connect();
                cmd.Connection = database.Connection;
                dbCommand = "SELECT * FROM PURCHASE";
                cmd.CommandText = dbCommand;
                reader = cmd.ExecuteReader();
                BInt = reader.FieldCount;
                Debug.WriteLine("BInt: " + BInt.ToString());
                for (int i = 0; i < BInt; i++)
                {
                    ColumnNames2.Add(reader.GetName(i));
                }
                int j = 0;
                while (reader.Read())
                {
                    Results2.Add(new List<string>());
                    for (int i = 0; i < BInt; i++)
                    {
                        Results2[j].Add(reader[i].ToString());
                    }
                    j++;
                }
                Debug.WriteLine("Results2 count: " + Results2.Count().ToString() + " j: " + j.ToString());
            }
            else if (we == "EMPLOYEE")
            {
                // load title type table
                //dbCommand = "SELECT * FROM TITLE_TYPE";
            }
            else if(we == "STORE")
            {
                // load store type table
                //dbCommand = "SELECT * FROM STORE_TYPE";
            }
        }

        public void OnPost()
        {
            AMessage = "posted";
            whichEntity = Request.Form["entityType"];
            database.connect();
            dbCommand = "SELECT * FROM " + whichEntity;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;
            reader = cmd.ExecuteReader();
            AInt = reader.FieldCount;
            Debug.WriteLine(AInt.ToString());
            string output = "";
            for(int i = 0; i < AInt; i++)
            {
                ColumnNames.Add(reader.GetName(i));
                output += reader.GetName(i);
            }
            Debug.WriteLine(output);
            output = "";
            int j = 0;
            while (reader.Read())
            {
                //Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                Results.Add(new List<string>());
                for (int i = 0; i < AInt; i++)
                {
                    output += reader[i] + ", ";
                    Results[j].Add(reader[i].ToString());
                }
                j++;
                output += '\n';
            }
            Debug.WriteLine("Results count: " + Results.Count());
            Debug.WriteLine(output);
            cmd.Dispose();
            database.disconnect();
            bool success = false;
            if (whichEntity == "ANIMAL")
            {
                AMessage = "controller recognized ANIMAL";  
               

                database.connect();
                
                string insertID = Request.Form["insertID"];
                if (string.IsNullOrEmpty(insertID) == true)
                {
                    // throw error 
                }
                string insertName = Request.Form["insertName"];
                if (string.IsNullOrEmpty(insertName) == true)
                {
                    // throw error 
                }
                string insertSpecies = Request.Form["insertSpecies"];
                if (string.IsNullOrEmpty(insertSpecies) == true)
                {
                    // throw error 
                }
                string insertTaxology = Request.Form["insertTaxology"];
                if (string.IsNullOrEmpty(insertTaxology) == true)
                {
                    // throw error 
                }
                string insertBirthLocation = Request.Form["insertBirthLocation"];
                if (string.IsNullOrEmpty(insertBirthLocation) == true)
                {
                    // NULL allowed
                    //insertBirthLocation = "NULL";
                }
                string insertBirthDate = Request.Form["insertBirthDate"];
                if (string.IsNullOrEmpty(insertBirthDate) == true)
                {
                    // NULL allowed
                    //insertBirthDate = "NULL";
                }
                string insertState = Request.Form["insertState"];
                if (string.IsNullOrEmpty(insertState) == true)
                {
                    // throw error 
                }
                string insertStatus_date = Request.Form["insertStatus_date"];
                if (string.IsNullOrEmpty(insertStatus_date) == true)
                {
                    // throw error 
                }
                string insertGender = Request.Form["insertGender"];
                if (string.IsNullOrEmpty(insertGender) == true)
                {
                    // throw error 
                }
                string insertHeight = Request.Form["insertHeight"];
                if (string.IsNullOrEmpty(insertHeight) == true)
                {
                    // NULL allowed
                    insertHeight = "NULL";
                }
                string insertWeight = Request.Form["insertWeight"];
                if (string.IsNullOrEmpty(insertWeight) == true)
                {
                    // NULL allowed
                    insertWeight = "NULL";
                }
                string insertHealth = Request.Form["insertHealth"];
                if (string.IsNullOrEmpty(insertHealth) == true)
                {
                    // NULL allowed
                    //insertHealth = "NULL";
                }
                string insertHealth_date = Request.Form["insertHealth_date"];
                if (string.IsNullOrEmpty(insertHealth_date) == true)
                {
                    // NULL allowed
                    //insertHealth_date = "NULL";
                }
                string insertAttraction = Request.Form["insertAttraction"];
                if (string.IsNullOrEmpty(insertAttraction) == true)
                {
                    // throw error 
                }

                //SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, [Name], Species, Taxology, " +
                    "[Birth Location], [Birth Date], Status, Status_date, Gender, Weight, Height, " +
                    "Health, Health_date, Attraction) " +
                    "VALUES(" + insertID + ", '" + insertName + "', '" + insertSpecies +
                     "', '" + insertTaxology + "', '" + insertBirthLocation + "', '" +
                     insertBirthDate + "', '" + insertState + "', '" + insertStatus_date +
                     "', " + insertGender + ", " + insertHeight + ", " + insertWeight +
                     ", '" + insertHealth + "', '" + insertHealth_date + "', " + insertAttraction +
                     ");";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "ATTRACTION")
            {
                AMessage = "controller recogznied ATTRACTION";

                database.connect();

                string insertID = Request.Form["insertID"];
                if(string.IsNullOrEmpty(insertID) == true)
                {
                    // throw error 
                }
                string insertType = Request.Form["insertType"];
                if (string.IsNullOrEmpty(insertType) == true)
                {
                    // throw error 
                }
                string insertOpen = Request.Form["insertOpen"];
                if (string.IsNullOrEmpty(insertOpen) == true)
                {
                    // throw error 
                }
                string insertOpenDate = Request.Form["insertOpenDate"];
                if (string.IsNullOrEmpty(insertOpenDate) == true)
                {
                    // throw error 
                }
                string insertManager = Request.Form["insertManager"];
                if (string.IsNullOrEmpty(insertManager) == true)
                { 
                    // throw error 
                }
                string insertManagerDate = Request.Form["insertManagerDate"];
                if (string.IsNullOrEmpty(insertManagerDate) == true)
                { 
                    // throw error 
                }                
                string insertDescription = Request.Form["insertDescription"];
                if (string.IsNullOrEmpty(insertDescription) == true)
                {
                    // NULL allowed
                    //insertDescription = "NULL";
                }
                cmd = new SqlCommand();
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
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "CUSTOMER")
            {
                AMessage = "controller recognized CUSTOMER";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertFname = Request.Form["insertFname"];
                string insertMname = Request.Form["insertMname"];
                string insertLname = Request.Form["insertLname"];
                string insertStreetAddress = Request.Form["insertStreetAddress"];
                string insertCityAddress = Request.Form["insertCityAddress"];
                string insertZipAddress = Request.Form["insertZipAddress"];
                string insertStateAddress = Request.Form["insertStateAddress"];
                string insertPhone = Request.Form["insertPhone"];
                string insertEmail = Request.Form["insertEmail"];
                string insertMembershipType = Request.Form["insertMembershipType"];
                string insertExpirationDate = Request.Form["insertExpirationDate"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Fname, Mname," +
                    " Lname, StreetAddress, CityAddress, ZipAddress, StateAddress, " +
                    " Phone, Email, MembershipType, ExpirationDate) " +
                    "VALUES(" + insertID + ", '" + insertFname + "', '" + insertMname + 
                    "', '" + insertLname + "', '" + insertStreetAddress + "', '" + 
                    insertCityAddress + "', " + insertZipAddress + ", '" + insertStateAddress + 
                    "', " + insertPhone + ", '" + insertEmail + "', " + insertMembershipType +
                    ", '" + insertExpirationDate + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "EMPLOYEE")
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
                if(string.IsNullOrEmpty(insertStore) == true)
                {
                    insertStore = "NULL";
                }
                string insertAttraction = Request.Form["insertAttraction"];
                if(string.IsNullOrEmpty(insertAttraction) == true)
                {
                    insertAttraction = "NULL";
                }

                cmd = new SqlCommand();
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
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "GENDER_TYPE")
            {
                AMessage = "controller recognized GENDER_TYPE";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertGender = Request.Form["insertGender"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Name) " +
                    "VALUES(" + insertID + ", '" + insertGender + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "MEMBERSHIP_TYPE")
            {
                AMessage = "controller recognized MEMBERSHIP_TYPE";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertType = Request.Form["insertType"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Name) " +
                    "VALUES(" + insertID + ", '" + insertType + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "PAY_TYPE")
            {
                AMessage = "controller recognized PAY_TYPE";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertType = Request.Form["insertPayType"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Name) " +
                    "VALUES(" + insertID + ", '" + insertType + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "PRODUCT")
            {
                AMessage = "controller recogznied PRODUCT";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertType = Request.Form["insertType"];
                string insertPrice = Request.Form["insertPrice"];
                string insertDescription = Request.Form["insertDescription"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Name, Price, Description) " +
                    "VALUES(" + insertID + ", '" + insertType + "', " + insertPrice +
                     ", '" + insertDescription + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "PURCHASE")
            {
                AMessage = "controller recognized PURCHASE";

                database.connect();

                string insertReceipt = Request.Form["insertReceipt"];
                string insertTime = Request.Form["insertTime"];
                string insertAmount = Request.Form["insertAmount"];
                string insertPay_option = Request.Form["insertPay_option"];
                string insertDate = Request.Form["insertDate"];
                string insertStore = Request.Form["insertStore"];
                string insertCustomer = Request.Form["insertCustomer"];
                if(string.IsNullOrEmpty(insertCustomer) == true)
                {
                    insertCustomer = "NULL";
                }

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(Receipt, Time, Amount, " +
                    "Pay_option, Date, Store, Customer) " +
                    "VALUES(" + insertReceipt + ", '" + insertTime + "', " + 
                    insertAmount + ", " + insertPay_option + ", '" + insertDate + 
                    "', " + insertStore + ", " + insertCustomer + ");";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "PURCHASE_INFO")
            {
                AMessage = "controller recognized PURCHASE_INFO";

                database.connect();

                string insertReceipt = Request.Form["insertReceipt"];
                string insertProduct = Request.Form["insertProduct"];
                string insertPrice = Request.Form["insertPrice"];
                string insertQuantity = Request.Form["insertQuantity"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(Receipt, Product, Price, " +
                    "Quantity) " +
                    "VALUES(" + insertReceipt + ", " + insertProduct + ", " +
                    insertPrice + ", " + insertQuantity + ");";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "STORE")
            {
                AMessage = "controller recognized STORE";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertName = Request.Form["insertName"];
                string insertType = Request.Form["insertType"];
                string insertManager = Request.Form["insertManager"];
                string insertManager_date = Request.Form["insertManager_date"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Name, Type, " +
                    "Manager, Manager_date) " +
                    "VALUES(" + insertID + ", '" + insertName + "', " +
                    insertType + ", " + insertManager + ", '" + insertManager_date + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "STORE_TYPE")
            {
                AMessage = "controller recognized STORE_TYPE";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertName = Request.Form["insertName"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Name) " +
                    "VALUES(" + insertID + ", '" + insertName + "');";

                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch (SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }

                cmd.Dispose();
                database.disconnect();
            }

            else if (whichEntity == "TITLE_TYPE")
            {
                AMessage = "controller recognized TITLE_TYPE";

                database.connect();

                string insertID = Request.Form["insertID"];
                string insertType = Request.Form["insertType"];

                cmd = new SqlCommand();
                cmd.Connection = database.Connection;
                dbCommand = "INSERT INTO " + whichEntity + "(ID, Title) " +
                    "VALUES(" + insertID + ", '" + insertType + "');";
                
                cmd.CommandText = dbCommand;

                try
                {
                    cmd.ExecuteNonQuery();
                    EMessage = "Insert successful";
                    success = true;
                }

                catch(SqlException e)
                {
                    EMessage = "Failed to execute insert: " + e.ToString();
                }
                
                cmd.Dispose();
                database.disconnect();
            }
            else { EMessage = "Could not find entity type."; }
            
            if(success)
            {
                Response.Redirect("./Search?we=" + whichEntity);
            }
        }
        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }

    }
}