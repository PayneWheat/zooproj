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
    public class LoginErrorModel : PageModel
    {

        public async Task<IActionResult> OnPostAsync()
        {
            string userName = "", password = "";
            if (!string.IsNullOrEmpty(Request.Form["Username"]))
            {
                userName = Request.Form["Username"];
            }
            else
            {
                return Redirect("/LoginError");
            }

            if (!string.IsNullOrEmpty(Request.Form["Password"]))
            {
                password = Request.Form["Password"];
            }
            else
            {
                return Redirect("/LoginError");
            }


            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, userName, ClaimValueTypes.String, "None")
            };

            var userIdentity = new ClaimsIdentity(claims, "Auth");

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
            //return RedirectToPage("/Index");
            return Redirect("./Employee_Section/");
        }
    }
}
