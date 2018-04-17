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

        public void OnGet()
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