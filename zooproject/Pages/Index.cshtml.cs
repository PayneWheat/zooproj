using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zooproject.Pages
{
    public class IndexModel : PageModel
    {
        IConfiguration _config;
        string connection_string;

        public IndexModel(IConfiguration iconfiguration)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public void OnGet()
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                // Connect to database 
                conn.Open();
                Console.WriteLine("Successfully opened an sql connection");
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ANIMAL", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Print names of all animals
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetValue(1));
                }

                // Cleanup
                reader.Close();
                cmd.Dispose();
                conn.Close();

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
