using System;
using System.Collections.Generic;
using System.Collections.Specialized
using System.Linq;
using System.Threading.Tasks;
using System.Web
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zooproject.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        
        }
        public void OnPost()
        {
            string userName, password;
            if (!string.IsNullOrEmpty(Request.Form["Username"]))
            {
                userName = Request.Form["Username"];
            }

            if (!string.IsNullOrEmpty(Request.Form["Password"]))
            {
                password = Request.Form["Password"];
            }

            //Process login
            //CheckLogin(userName, password);
        }
    }
}
