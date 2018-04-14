using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace zooproject.Pages.Employee_Section
{
    public class InsertModel : PageModel
    {
        public string AMessage = "";
        public void OnGet()
        {
           
        }

        public void OnInsert()
        {
            AMessage = "Inserted";
        }

        public void OnPost()
        {
            AMessage = "posted";
        }
        
    }
}