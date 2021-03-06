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
        public List<List<string>> ProductResults = new List<List<string>>();
        public List<List<string>> EmployeeResults = new List<List<string>>();

        public int AInt = 0;
        public int BInt = 0;
        public int SInt = 0;
        public int TInt = 0;
        public int PInt = 0;
        public int EInt = 0;

        public string StorePurchaseNum;
        public decimal StoreRevenue;
        public int StoreItems;
        public decimal StoreAverage;


        public string sD = ""; //start date
        public string eD = ""; //end date
        public string sT = ""; //start time
        public string eT = ""; //end time
        public int sS = -1; //store selection
        public int eID = -1; //employee ID
        public int pID = -1; //product ID
        public int pName = -1;

        public int purchaseCount = 0;
        public int ticketsSold = 0;

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

        public void OnGet(string startDate = "", string endDate = "", string startTime = "", string endTime = "", int storeSelect = -1, string employeeFName = "", 
            string employeeLName = "", int employeeID = -1, string employeeTitle = "", int productID = -1, int productName = -1)
        {
            sD = startDate;
            eD = endDate;
            sT = startTime;
            eT = endTime;
            sS = storeSelect;
            eID = employeeID;
            pID = productID;
            pName = productName;
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
            cmd = new SqlCommand();
            dbCommand = "SELECT ID, Name FROM PRODUCT;";
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;
            reader = cmd.ExecuteReader();
            colCount = reader.FieldCount;
            j = 0;
            while (reader.Read())
            {
                ProductResults.Add(new List<string>());
                for (int i = 0; i < colCount; i++)
                {
                    ProductResults[j].Add(reader[i].ToString());
                }
                j++;
            }
            PInt = j;
            cmd.Dispose();
            database.disconnect();

            database.connect();
            cmd = new SqlCommand();
            dbCommand = "SELECT ID, Lname, Fname FROM EMPLOYEE ORDER BY Lname";
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;
            reader = cmd.ExecuteReader();
            colCount = reader.FieldCount;
            j = 0;
            while (reader.Read())
            {
                EmployeeResults.Add(new List<string>());
                for (int i = 0; i < colCount; i++)
                {
                    EmployeeResults[j].Add(reader[i].ToString());
                }
                j++;
            }
            EInt = j;
            cmd.Dispose();
            database.disconnect();

            database.connect();
            cmd.Connection = database.Connection;
            cmd = new SqlCommand();
            //dbCommand = "SELECT PUR.*, PURINFO.* FROM PURCHASE PUR LEFT JOIN PURCHASE_INFO PURINFO ON PUR.Receipt = PURINFO.Receipt";
            string whereAndClause = "";
            string whereClause = "";
            //string whereAndClause = "AND PURCHASE.Store=5";
            //string whereAndClause = "AND PURCHASE_INFO.Product = 1";
            //string whereAndClause = "AND PURCHASE.Date BETWEEN '2018/04/12' AND '2018/04/19'"; 
            Debug.WriteLine("pID: " + productID);
            if (startDate != "" && endDate == "")
            {
                // only starting date set, render single day view
                // show sales by time?
                whereAndClause = "AND PURCHASE.Date='" + startDate + "'";
                sD = startDate;
                whereClause = " PURCHASE.Date='" + startDate + "'";
            } else if (startDate != "" && endDate != "")
            {
                // both starting and ending date set
                // only display graph is number of days is greater than 3 or 4?
                whereAndClause = "AND PURCHASE.Date BETWEEN '" + startDate + "' AND '" + endDate + "'";
                sD = startDate;
                eD = endDate;
                whereClause = " PURCHASE.Date BETWEEN '" + startDate + "' AND '" + endDate + "'";
            }
            if(startTime != "" && endTime != "")
            {
                // validate client side both fields are filled out or neither are.
                whereAndClause = "AND PURCHASE.Time BETWEEN '" + startTime + "' AND '" + endTime + "'";
                sT = startTime;
                eT = endTime;
            }
            if (storeSelect != -1)
            {
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
                // add employee id to whereAndClause
                whereAndClause += "AND PURCHASE.Employee=" + employeeID + " ";
                eID = employeeID;
            }
            /*
            if(employeeTitle != "")
            {
                //whereAndClause += "AND PURCHASE.Employee=" + employeeID + " ";
            }
            */
            if (productID != -1)
            {
                // add product id to whereAndClause
                whereAndClause += "AND PURCHASE_INFO.Product =" + productID + " ";
                pID = productID;
            }
            

            dbCommand = @"SELECT DISTINCT CONVERT(DATE, C.PurDate, 101) PurchaseDate,
SUM(C.RecTotal) DailySales
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
ORDER BY PurchaseDate ASC;";
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
            database.connect();
            cmd.Connection = database.Connection;
            cmd = new SqlCommand();
            string tempWhere = "";
            if(!String.IsNullOrEmpty(whereClause))
                tempWhere = "WHERE" + whereClause;
            dbCommand = "SELECT COUNT(*) PurchaseCount FROM PURCHASE " + tempWhere;
            Debug.WriteLine("dbCommand: " + dbCommand);
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;
            purchaseCount = (int)cmd.ExecuteScalar();

            database.disconnect();
            database.connect();
            cmd.Connection = database.Connection;
            cmd = new SqlCommand();
            if (!String.IsNullOrEmpty(whereClause))
                tempWhere = "AND" + whereClause;
            dbCommand = "SELECT SUM(Quantity) TicketsSold FROM PURCHASE_INFO, PURCHASE WHERE PURCHASE.Receipt = PURCHASE_INFO.Receipt AND PURCHASE_INFO.Product = 1 " + tempWhere;
            Debug.WriteLine("dbCommand: " + dbCommand);
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;

            //ticketsSold = (int)cmd.ExecuteScalar();
            ticketsSold = (cmd.ExecuteScalar() == DBNull.Value) ? 0 : (int)cmd.ExecuteScalar();
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