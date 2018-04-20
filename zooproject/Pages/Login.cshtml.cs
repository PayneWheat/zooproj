using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace zooproject.Pages
{
    public class LoginModel : PageModel
    {
        public bool login_failed = false;
        IConfiguration _config;
        Database database;
        string connection_string;

        public LoginModel(IConfiguration iconfiguration, Database ZooDatabase)
        {
            // Get database connection string from appsettings.Development.json
            _config = iconfiguration;
            database = ZooDatabase;
            connection_string = _config.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            string userName="", password="";
            if (!string.IsNullOrEmpty(Request.Form["Username"]))
            {
                userName = Request.Form["Username"];
            }
            else
            {
                login_failed = true;
            }

            if (!string.IsNullOrEmpty(Request.Form["Password"]))
            {
                password = Request.Form["Password"];
            }
            else
            {
                login_failed = true;
            }

            string role = "";

            if (isCustomer(userName))
            {
                role = "Customer";
            }else if(isEmployee(userName))
            {
                role = getRole(userName);
            }
            else
            {
                login_failed = true;
            }
                


            if (login_failed)
                return Redirect("/LoginError");
            

            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, userName, ClaimValueTypes.String, "Manager"),
                    new Claim(ClaimTypes.Role, role, ClaimValueTypes.String)
            };

            var userIdentity = new ClaimsIdentity(claims, "Auth");

            var userPrincipal = new ClaimsPrincipal(userIdentity);
                
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
                
            if(role == "Manager" || role == "Employee")
            {
                return Redirect("./Employee_Section/");
            }
            else
            {
                return Redirect("./Customer_Section/Account");
            }
                
        }
        private bool isEmployee(string username)
        {
            database.connect();
            SqlCommand cmd = new SqlCommand("SELECT id FROM EMPLOYEE WHERE Fname='" + username + "'",
                database.Connection);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            bool user_found = false;
            while (reader.Read())
            {
                user_found = true;
            }

            cmd.Dispose();
            reader.Close();
            database.disconnect();

            return user_found;
        }

        private bool isCustomer(string username)
        {
            database.connect();
            SqlCommand cmd = new SqlCommand("SELECT id FROM Customer WHERE Fname='" + username + "'",
                database.Connection);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            bool user_found = false;
            while (reader.Read())
            {
                user_found = true;
            }

            cmd.Dispose();
            reader.Close();
            database.disconnect();

            return user_found;
        }

        private string getRole(string username)
        {
            database.connect();
            SqlCommand cmd = new SqlCommand("SELECT Title FROM EMPLOYEE WHERE Fname='" + username + "'",
                database.Connection);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            bool user_found = false;
            int roleid = 0;
            string role = "Employee";

            while (reader.Read())
            {
                roleid = reader.GetInt32(0);
                user_found = true;
            }
            cmd.Dispose();
            reader.Close();
            database.disconnect();
            if(roleid == 3)
            {
                return "Manager";
            }
            else
            {
                return "Employee";
            }
        }
    }
}
