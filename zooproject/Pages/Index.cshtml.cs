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
        //a

        public string AMessage { get; set; }
        public string BMessage { get; set; }
        public int AInt { get; set; }
        public SqlDataReader animals { get; set; }

        public string insertType;
        public int insertID;

        //Lists to store types and IDs
        public List<string> TypeResults = new List<string>();
        public List<int> IDResults = new List<int>();
        public List<int> AnimalIDs = new List<int>();

        IConfiguration _config;
        Database database;
        string connection_string;

        public IndexModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public void OnGet()
        {
            AMessage = "nothing";
            AInt = 0;
            //InsertInto();
            //Select();
            //Test();
            //InsertInto();
            //Select();
        }

        public void Test()
        {
            //connection
            database.connect();

            SqlCommand cmd = new SqlCommand()
            {
                Connection = database.Connection,
                CommandText = "SELECT ID FROM [dbo].ANIMAL"
            };

            SqlDataReader reader;

            animals = cmd.ExecuteReader();
            while (animals.Read())
            {
                AnimalIDs.Add(animals.GetInt32(0));
            }
            database.disconnect();

        }

        public void InsertInto()
        {
            //connection
            //"Data Source=(local);Initial Catalog=Zoo;Integrated Security=SSPI"
            database.connect();
            AMessage = "Successfully opened an sql connection";

            //Insertion of Title_Type
            SqlCommand cmd2 = new SqlCommand()
            {
                Connection = database.Connection,
                CommandText = "INSERT INTO [dbo].[TITLE_TYPE](ID, Title) VALUES(@param1, @param2)"
            };
            cmd2.Parameters.AddWithValue("@param1", AInt);
            cmd2.Parameters.AddWithValue("@param2", AMessage);

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
            cmd2.Dispose();
            database.disconnect();

        }

        public void Select()
        {
            // Connect to database 
            database.connect();

            //Adds all IDs and Titles to Model.listname
            SqlCommand cmd = new SqlCommand("SELECT ID FROM [dbo].ANIMAL", database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                IDResults.Add(reader.GetInt32(0));
                //TypeResults.Add(reader.GetString(1));
            }

            // Cleanup
            reader.Close();
            cmd.Dispose();
            database.disconnect();
        }

    }
}
