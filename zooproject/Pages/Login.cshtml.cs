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
            NameValueCollection nvc = Request.Form;
            string userName, password;
            if (!string.IsNullOrEmpty(nvc["Username"]))
            {
                userName = nvc["Username"];
            }

            if (!string.IsNullOrEmpty(nvc["Password"]))
            {
                password = nvc["Password"];
            }

            //Process login
            //CheckLogin(userName, password);
        }
    }
}
