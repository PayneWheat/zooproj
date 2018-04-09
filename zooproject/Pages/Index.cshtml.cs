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

        public string insertType;
        public int insertID;

        //Lists to store types and IDs
        public List<string> TypeResults = new List<string>();
        public List<int> IDResults = new List<int>();
        


        

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
            //InsertInto();
            Select();
        }

        public void InsertInto()
        {
            //connection
            //"Data Source=(local);Initial Catalog=Zoo;Integrated Security=SSPI"
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Zoo;Integrated Security=SSPI");
            conn.Open();
            AMessage = "Successfully opened an sql connection";

            //Insertion of Title_Type
            SqlCommand cmd2 = new SqlCommand()
            {
                Connection = conn,
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
            conn.Close();
            cmd2.Dispose();

        }

        public void Select()
        {
            // Connect to database 
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Zoo;Integrated Security=SSPI");
            conn.Open();

            //Adds all IDs and Titles to Model.listname
            SqlCommand cmd = new SqlCommand("SELECT ID, Title FROM [dbo].[TITLE_TYPE]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                IDResults.Add(reader.GetInt32(0));
                TypeResults.Add(reader.GetString(1));
            }

            // Cleanup
            reader.Close();
            cmd.Dispose();
            conn.Close();
        }

    }
}
