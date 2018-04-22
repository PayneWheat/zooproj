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
    public class SalesReportsModel : PageModel
    {
        public string secondTableChoice = "";
        public string storeChoice = "";
        public string AMessage = "";
        public string secondTableStoreChoice = "";
        public string secondTableDateChoice = "";

        public List<DateTime> PurchaseDateList = new List<DateTime>();
        public List<decimal> PurchaseAmountList = new List<decimal>();
        public List<int> PurchaseQuantityList = new List<int>();

        public List<List<string>> ViewResults = new List<List<string>>();
        public List<string> ViewColumns = new List<string>();
        public List<List<string>> StoreResults = new List<List<string>>();
        public List<List<string>> TitleResults = new List<List<string>>();

        public int AInt = 0;
        public int BInt = 0;
        public int SInt = 0;
        public int TInt = 0;

        public string StorePurchaseNum;
        public decimal StoreRevenue;
        public int StoreItems;
        public decimal StoreAverage;

        public string dbCommand;
        IConfiguration _config;
        Database database;
        string connection_string;

        public SalesReportsModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public void OnGet(string startDate = "", string endDate = "", string startTime = "", string endTime = "", int storeSelect = -1, string employeeFName = "", string employeeLName = "", int employeeID = -1, string employeeTitle = "", int productID = -1, string productName = "")
        {

            /*
            SqlCommand cmd = new SqlCommand("SELECT Date, SUM(PURCHASE.Amount) AS Revenue, " +
                "SUM(PURCHASE_INFO.Quantity) AS 'Items Purchased' FROM PURCHASE, PURCHASE_INFO " +
                " WHERE PURCHASE_INFO.Receipt = PURCHASE.Receipt GROUP BY Date;", 
                database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PurchaseDateList.Add(reader.GetDateTime(0));
                PurchaseAmountList.Add(reader.GetDecimal(1));
                PurchaseQuantityList.Add(reader.GetInt32(2));
            }
            */

            // no parameters set... render all sales.
            database.connect();
            SqlCommand cmd = new SqlCommand();
            /*
            dbCommand = "CREATE VIEW [CurSalesReport] AS SELECT * FROM PURCHASE;";
            cmd.CommandText = dbCommand;
            cmd.Connection = database.Connection;
            cmd.ExecuteReader();
            cmd.Dispose();
            database.disconnect();
            database.connect();
            */
            // fetch store info for drop down field
            dbCommand = "SELECT ID, Name FROM STORE;";
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;
            SqlDataReader reader = cmd.ExecuteReader();
            int colCount = reader.FieldCount;
            int j = 0;
            while (reader.Read())
            {
                StoreResults.Add(new List<string>());
                for (int i = 0; i < colCount; i++)
                {
                    StoreResults[j].Add(reader[i].ToString());
                }
                j++;
            }
            SInt = j;
            cmd.Dispose();
            database.disconnect();

            database.connect();
            cmd = new SqlCommand();
            dbCommand = "SELECT ID, Title FROM TITLE_TYPE;";
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;
            reader = cmd.ExecuteReader();
            colCount = reader.FieldCount;
            j = 0;
            while (reader.Read())
            {
                TitleResults.Add(new List<string>());
                for (int i = 0; i < colCount; i++)
                {
                    TitleResults[j].Add(reader[i].ToString());
                }
                j++;
            }
            TInt = j;
            cmd.Dispose();
            database.disconnect();

            database.connect();
            cmd.Connection = database.Connection;
            cmd = new SqlCommand();
            //dbCommand = "SELECT PUR.*, PURINFO.* FROM PURCHASE PUR LEFT JOIN PURCHASE_INFO PURINFO ON PUR.Receipt = PURINFO.Receipt";
            string whereAndClause = "";
            //string whereAndClause = "AND PURCHASE.Store=5";
            //string whereAndClause = "AND PURCHASE_INFO.Product = 1";
            //string whereAndClause = "AND PURCHASE.Date BETWEEN '2018/04/12' AND '2018/04/19'"; 
            Debug.WriteLine("pID: " + productID);
            if (startDate != "" && endDate == "")
            {
                Debug.WriteLine("only starting date set, render single day view");
                Debug.WriteLine(startDate);
                // only starting date set, render single day view
                // show sales by time?
                whereAndClause = "AND PURCHASE.Date='" + startDate + "'";
            } else if (startDate != "" && endDate != "")
            {
                Debug.WriteLine("both starting and ending date set");
                // both starting and ending date set
                // only display graph is number of days is greater than 3 or 4?
                whereAndClause = "AND PURCHASE.Date BETWEEN '" + startDate + "' AND '" + endDate + "'"; ;
            }
            if(startTime != "" && endTime != "")
            {
                whereAndClause = "AND PURCHASE.Time BETWEEN '" + startTime + "' AND '" + endTime + "'"; ;
            }
            if (storeSelect != -1)
            {
                Debug.WriteLine("add store id to whereAndClause");
                // add store id to whereAndClause
                whereAndClause += "AND PURCHASE.Store=" + storeSelect + " ";
            }
            /*
            if(employeeFName != "")
            {
                whereAndClause += "AND EMPLOYEE.Fname='" + employeeFName + "' ";
            }
            if(employeeLName != "")
            {
                whereAndClause += "AND EMPLOYEE.Fname='" + employeeLName + "' ";
            }
            */
            if (employeeID != -1)
            {
                Debug.WriteLine("add employee id to whereAndClause");
                // add employee id to whereAndClause
                whereAndClause += "AND PURCHASE.Employee=" + employeeID + " ";
            }
            if(employeeTitle != "")
            {
                //whereAndClause += "AND PURCHASE.Employee=" + employeeID + " ";
            }
            if (productID != -1)
            {
                Debug.WriteLine("add product id to whereAndClause");
                // add product id to whereAndClause
                whereAndClause += "AND PURCHASE_INFO.Product =" + productID + " ";
            }
            if(productName != "")
            {
                Debug.WriteLine("add payment type to whereAndClause");
                // add payment type to whereAndClause
            }


            dbCommand = @"SELECT DISTINCT C.PurDate,
SUM(C.RecTotal)
FROM
(SELECT PURCHASE.Date AS PurDate,
B.ReceiptTotal AS RecTotal
FROM PURCHASE,
(SELECT A.Receipt, PURCHASE.Store, PURCHASE.Date,
SUM(A.ItemTotal) AS ReceiptTotal
FROM PURCHASE, (SELECT PURCHASE_INFO.Quantity,
PURCHASE_INFO.Price,
PURCHASE_INFO.Quantity * PURCHASE_INFO.Price AS ItemTotal,
PURCHASE.Receipt
FROM PURCHASE_INFO, PURCHASE
WHERE PURCHASE_INFO.Receipt = PURCHASE.Receipt " + whereAndClause + @" ) A
WHERE A.Receipt = PURCHASE.Receipt
GROUP BY PURCHASE.Date, PURCHASE.Store, A.Receipt) B
WHERE PURCHASE.Date = B.Date 
GROUP BY PURCHASE.Date, B.ReceiptTotal) C
GROUP BY C.PurDate
ORDER BY C.PurDate;";
            Debug.WriteLine(dbCommand);
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;
            reader = cmd.ExecuteReader();
            AInt = reader.FieldCount;
            Debug.Write("Adding columns: ");
            for(int i = 0; i < AInt; i++)
            {
                ViewColumns.Add(reader.GetName(i).ToString());
                Debug.Write(ViewColumns[i] + ", ");
            }
            Debug.WriteLine("\nAdding Results...");
            j = 0;
            while(reader.Read())
            {
                ViewResults.Add(new List<string>());
                for (int i = 0; i < AInt; i++)
                {
                    ViewResults[j].Add(reader[i].ToString());
                    Debug.Write(ViewResults[j][i].ToString() + ", ");
                }
                Debug.Write("\n");
                j++;
            }
            BInt = j;
            cmd.Dispose();
            database.disconnect();
            
        }
        public void OnPost()
        {
            database.connect();

            SqlCommand cmd = new SqlCommand("SELECT Date, SUM(PURCHASE.Amount) AS Revenue, " +
                "SUM(PURCHASE_INFO.Quantity) AS 'Items Purchased' FROM PURCHASE, PURCHASE_INFO " +
                " WHERE PURCHASE_INFO.Receipt = PURCHASE.Receipt GROUP BY Date;",
                database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PurchaseDateList.Add(reader.GetDateTime(0));
                PurchaseAmountList.Add(reader.GetDecimal(1));
                PurchaseQuantityList.Add(reader.GetInt32(2));
            }

            cmd.Dispose();
            reader.Close();

            secondTableChoice = Request.Form["storeChoice"];

            if(secondTableChoice != "")
            {
                AMessage = "second table chosen";
                parseTableChoice();

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = database.Connection;
                SqlDataReader reader2;

                if (secondTableStoreChoice == "Ticket Booths")
                    secondTableStoreChoice = "1";
                if (secondTableStoreChoice == "Restaurants")
                    secondTableStoreChoice = "2";
                if (secondTableStoreChoice == "Gift Shops")
                    secondTableStoreChoice = "3";

                dbCommand = 
                "SELECT COUNT(P.Receipt) AS '#Purchases', SUM(P.Amount) AS 'Revenue', SUM(I.Quantity) AS '#Items'" +
                "FROM PURCHASE AS P, STORE AS S, PURCHASE_INFO AS I " +
                "WHERE S.Type = " + secondTableStoreChoice + " AND P.Store = S.ID AND " +
                "I.Receipt = P.Receipt AND P.Date = '" + secondTableDateChoice + "'";

                cmd2.CommandText = dbCommand;

                try{
                    reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        StorePurchaseNum = reader2.GetValue(0).ToString();
                        StoreRevenue = reader2.GetDecimal(1);
                        StoreItems = reader2.GetInt32(2);
                        StoreAverage = StoreRevenue / StoreItems;
                    }

                    reader2.Close();
                }
                catch(Exception e)
                {

                }

                if (secondTableStoreChoice == "1")
                    secondTableStoreChoice = "Ticket Booths";
                if (secondTableStoreChoice == "2")
                    secondTableStoreChoice = "Restaurants";
                if (secondTableStoreChoice == "3")
                    secondTableStoreChoice = "Gift Shops";

                cmd2.Dispose();
                database.disconnect();
            }
        }

        public void parseTableChoice()
        {
            int i = 0;
            int j = 0;

            while (secondTableChoice[i] != ',')
                i++;
            secondTableStoreChoice = string.Concat(secondTableStoreChoice, secondTableChoice.Substring(j, i - j));
            i += 2;
            j = i;
            while (secondTableChoice[i] != ' ')
                i++;
            secondTableDateChoice = string.Concat(secondTableDateChoice, secondTableChoice.Substring(j, i - j));
        }
    }
}