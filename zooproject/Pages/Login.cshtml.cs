using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zooproject.Pages
{
    public class LoginModel : PageModel
    {
        public bool login_failed = false;

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
            if(login_failed)
                return Redirect("/LoginError");

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, userName, ClaimValueTypes.String, "Manager")
            };

            var userIdentity = new ClaimsIdentity(claims, "Passport");

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
            return Redirect("./Employee_Section/");
        }
    }
}
