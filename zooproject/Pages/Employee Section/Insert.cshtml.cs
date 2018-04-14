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
        public string whichEntity = "";

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
            whichEntity = Request.Form["entityType"];

            if (whichEntity == "TITLE_TYPE")
            {
                //AMessage = "controller recognized TITLE_TYPE";
                AMessage = Request.Form["insertID"];
            }

            if (whichEntity == "ATTRACTION")
                AMessage = "controller recogznied ATTRACTION";
        }
        
    }
}