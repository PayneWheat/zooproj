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
        public List<int> PurchaseReciptList = new List<int>();
        public List<TimeSpan> PurchaseTimeList = new List<TimeSpan>();
        public List<decimal> PurchaseAmountList = new List<decimal>();
        public List<int> PurchasePayTypeList = new List<int>();
        public List<DateTime> PurchaseDateList = new List<DateTime>();
        public List<int> PurchaseStoreList = new List<int>();
        public List<int> PurchaseCustomerList = new List<int>();

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
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[PURCHASE]", 
                database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PurchaseReciptList.Add(reader.GetInt32(0));
                PurchaseTimeList.Add(reader.GetTimeSpan(1));
                PurchaseAmountList.Add(reader.GetDecimal(2));
                PurchasePayTypeList.Add(reader.GetInt32(3));
                PurchaseDateList.Add(reader.GetDateTime(4));
                PurchaseStoreList.Add(reader.GetInt32(5));
                PurchaseCustomerList.Add(reader.GetInt32(6));
            }
        }
    }
}