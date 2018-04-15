
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace zooproject.Pages
{
    public class PurchaseInfoModel : PageModel
    {
        public string errorMessage { get; set; }

        public List<int> receiptID = new List<int>();       //not sure if these four will work, modified attraction info for these 
        public List<int> product = new List<int>();
        public List<int> quantity = new List<int>();
        public List<decimal> price = new List<decimal>();

        IConfiguration _config;
        Database database;
        string connection_string;

        public PurchaseInfoModel (IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public void OnGet()
        {
            // Connect to database 
            database.connect();

            //Adds all IDs and Titles to Model.listname
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[PURCHASE_INFO]", 
                database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                receiptID.Add(reader.GetInt32(0));     
                product.Add(reader.GetInt32(1));
                quantity.Add(reader.GetInt32(2));
                price.Add(reader.GetDecimal(3));
            }

            // Cleanup
            reader.Close();
            cmd.Dispose();
            database.disconnect();
        }
    }
}
