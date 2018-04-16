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
    public class UpdateModel : PageModel
    {
        IConfiguration _config;
        Database database;
        string connection_string;

        public string dbCommand;
        public string EMessage;

        public UpdateModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public void OnPost()
        {
            database.connect();
            SqlCommand cmd = new SqlCommand();

            dbCommand = Request.Form["command"];

            cmd.CommandText = dbCommand;
            cmd.Connection = database.Connection;

            try
            {
                cmd.ExecuteNonQuery();
                EMessage = "query successful";
            }

            catch (SqlException e)
            {
                EMessage = "Failed to execute SqlQuery";
            }

            cmd.Dispose();
            database.disconnect();
        }
    }
}