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
        public string AMessage { get; set; }
        public string BMessage { get; set; }
        public int AInt { get; set; }
        public SqlDataReader animals { get; set; }

        IConfiguration _config;
        Database _database;
        string connection_string;

        public IndexModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            _database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public void OnGet()
        {
            AMessage = "nothing";
            AInt = 0;
            InsertInto();
            //Select();
            Test();
            
        }

        public void Test()
        {
            //connection
            _database.connect();

            //Insertion of Title_Type
            SqlCommand cmd2 = new SqlCommand()
            {
                Connection = _database.Connection,
                CommandText = "SELECT ID FROM [dbo].ANIMAL"
            };

            animals = _database.Select(cmd2);

        }

        public void InsertInto()
        {
            //connection
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();
            AMessage = "Successfully opened an sql connection";


            //Insertion of Title_Type
            SqlCommand cmd2 = new SqlCommand()
            {
                Connection = conn,
                CommandText = "INSERT INTO [dbo].[TITLE_TYPE](ID, Title) VALUES(@param1, @param2)"
            };
            cmd2.Parameters.AddWithValue("@param1", 14);
            cmd2.Parameters.AddWithValue("@param2", "Monkey Man");

            try
            {
                cmd2.ExecuteNonQuery();
                BMessage = "Executed insert";
            }
            catch (SqlException e)
            {
                BMessage = "Failed to execute insert";
            }

            //cleanup
            conn.Close();
            cmd2.Dispose();

        }

        public void Select()
        {
            // Connect to database 
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            // Prints last Title_type
            SqlCommand cmd = new SqlCommand("SELECT ID, Title FROM [dbo].[TITLE_TYPE]", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AMessage = reader.GetString(1);
                AInt = reader.GetInt32(0);
            }

            // Cleanup
            reader.Close();
            cmd.Dispose();
            conn.Close();
        }

    }
}
