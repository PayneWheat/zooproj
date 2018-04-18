using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace zooproject
{
    public class EmployeeModel
    {
        //a

        public SqlDataReader employees { get; set; }
        public List<int> employeesList = new List<int>();
        public int AInt { get; set; }
        public SqlDataReader reader;
        IConfiguration _config;
        Database database;
        string connection_string;
        public List<List<string>> Results = new List<List<string>>();
        public List<string> ColumnNames = new List<string>();

        public EmployeeModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public void OnGet()
        {
            database.connect();
            SqlCommand cmd = new SqlCommand()
            {
                Connection = database.Connection,
                CommandText = "SELECT * FROM [dbo].EMPLOYEE"
            };
            reader = cmd.ExecuteReader();
            int j = 0;
            AInt = reader.FieldCount;
            while (reader.Read())
            {
                for (; j < reader.FieldCount; j++)
                {
                    ColumnNames.Add(reader.GetName(j));
                }

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.IsDBNull(i) == false)
                        Results[i].Add(reader.GetValue(i).ToString());
                    else
                    {
                        Results[i].Add("NULL");
                    }
                }
            }
            database.disconnect();
        }

    }
}



