using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
            string pass = "";
            int id = 0;
            if (isCustomer(userName))
            {
                role = "Customer";
                id = getCustomerId(userName);
                pass = get_customer_password(id);
                if (!authenticate_password(password, pass))
                    login_failed = true;
                
            }else if(isEmployee(userName))
            {
                role = getRole(userName);
                id = getUserId(userName);
                pass = get_employee_password(id);
                if (!authenticate_password(password, pass))
                    login_failed = true;
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

        bool authenticate_password(string input, string pass_hash)
        {
            byte[] salt = new byte[128 / 8];
            Array.Clear(salt, 0, 128 / 8);
            using (var rng = RandomNumberGenerator.Create())
            {
                //rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            if (hashed == pass_hash)
                return true;
            else
                return false;
        }

        private string get_employee_password(int id)
        {
            database.connect();
            string cmd_text = "SELECT password_hash FROM employee_auth WHERE employee_id=@id";

            SqlCommand cmd = new SqlCommand(cmd_text, database.Connection);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@id"].Value = id;

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            string password = "";
            while (reader.Read())
            {
                password = reader.GetString(0);
            }

            cmd.Dispose();
            reader.Close();
            database.disconnect();

            return password;
        }

        private string get_customer_password(int id)
        {
            database.connect();
            string cmd_text = "SELECT password_hash FROM auth WHERE user_id=@id";

            SqlCommand cmd = new SqlCommand(cmd_text, database.Connection);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@id"].Value = id;

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            string password = "";
            while (reader.Read())
            {
                password = reader.GetString(0);
            }

            cmd.Dispose();
            reader.Close();
            database.disconnect();

            return password;
        }

        private bool isEmployee(string username)
        {
            database.connect();
            string cmd_text = "SELECT id FROM EMPLOYEE WHERE Fname=@username";

            SqlCommand cmd = new SqlCommand(cmd_text, database.Connection);
            cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;

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

        private int getUserId(string username)
        {
            database.connect();
            string cmd_text = "SELECT id FROM EMPLOYEE WHERE Fname=@username";

            SqlCommand cmd = new SqlCommand(cmd_text, database.Connection);
            cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            bool user_found = false;
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
                user_found = true;
            }

            cmd.Dispose();
            reader.Close();
            database.disconnect();

            return id;
        }

        private int getCustomerId(string username)
        {
            database.connect();
            string cmd_text = "SELECT id FROM CUSTOMER WHERE Fname=@username";

            SqlCommand cmd = new SqlCommand(cmd_text, database.Connection);
            cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            bool user_found = false;
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
                user_found = true;
            }

            cmd.Dispose();
            reader.Close();
            database.disconnect();

            return id;
        }

        private bool isCustomer(string username)
        {
            database.connect();
            string cmd_text = "SELECT id FROM CUSTOMER WHERE Fname=@username";

            SqlCommand cmd = new SqlCommand(cmd_text, database.Connection);
            cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;

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
            string cmd_text = "SELECT Title FROM EMPLOYEE WHERE Fname=@username";

            SqlCommand cmd = new SqlCommand(cmd_text, database.Connection);
            cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;

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
