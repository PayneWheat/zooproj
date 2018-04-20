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

            database.connect();
            SqlCommand cmd = new SqlCommand("SELECT id FROM EMPLOYEE WHERE Fname='" + userName + "'",
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

            if (!user_found)
                login_failed = true;


            if (login_failed)
                return Redirect("/LoginError");
            else
            {

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, userName, ClaimValueTypes.String, "Manager")
                };

                var userIdentity = new ClaimsIdentity(claims, "EmployeeLogin");

                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
            }
            return Redirect("./Employee_Section/");
        }
    }
}
