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
    public class ProductCatalogModel : PageModel
    {
        public string errorMessage { get; set; }

        public List<int> IDResults = new List<int>();
        public List<string> NameResults = new List<string>();
        public List<decimal> PriceResults = new List<decimal>();
        public List<string> DescriptionResults = new List<string>();

        IConfiguration _config;
        Database database;
        string connection_string;

        public ProductCatalogModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public void OnGet()
        {
            database.connect();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[PRODUCT]", 
                database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                IDResults.Add(reader.GetInt32(0));
                NameResults.Add(reader.GetString(1));
                PriceResults.Add(reader.GetDecimal(2));
                DescriptionResults.Add(reader.GetString(3));
            }

            // Cleanup
            reader.Close();
            cmd.Dispose();
            database.disconnect();
        }
    }
}
