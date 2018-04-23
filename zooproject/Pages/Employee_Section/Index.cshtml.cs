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
    public class EmployeeIndexModel : PageModel
    {
        IConfiguration _config;
        Database database;
        string connection_string;

        public int AInt = 0;
        public DateTime today = DateTime.Now;
        public List<string> ColumnNames = new List<string>();
        public List<List<string>> Results = new List<List<string>>();

        public EmployeeIndexModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;
        }
        public void OnGet()
        {
            database.connect();
            string dbCommand;
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand();

            dbCommand = @"SELECT A.Time Time,
(P.Quantity * P.Price) Total
FROM PURCHASE_INFO P,
(SELECT X.Receipt, X.Time FROM PURCHASE X WHERE Date = '" + today.ToString() + @"') A
WHERE A.Receipt = P.Receipt;";
            Debug.WriteLine("dbCommand: " + dbCommand);
            cmd.Connection = database.Connection;
            cmd.CommandText = dbCommand;
            reader = cmd.ExecuteReader();
            AInt = reader.FieldCount;
            for (int i = 0; i < AInt; i++)
            {
                ColumnNames.Add(reader.GetName(i));
            }

            int j = 0;
            while (reader.Read())
            {
                Results.Add(new List<String>());
                //Debug.WriteLine("New list appended to results list");
                for (int i = 0; i < AInt; i++)
                {
                    Results[j].Add(reader[i].ToString());
                }
                //Debug.WriteLine("List completed. Should have " + AInt + " entries: " + Results[j].Count());
                j++;
            }
        }
    }
}