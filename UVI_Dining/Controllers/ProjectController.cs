using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UVI_Dining.Models;


namespace UVI_Dining.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
                  
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult logtest(MYSQL_CON model)
        {
            var log = new MYSQL_CON()
            {      
                Email = Request.Form["Email"],
                Password = Request.Form["Password"]
               
            };
            //this is where I'm having problem
            if (model.Email == null && model.Password == null)
            {
                Response.Redirect("login.cshtml");
            }
          

            log.logtest();
            return View();
        }
        //FOR THE PROJECT 


        public IActionResult SignUp()
        {
            var testing = new MYSQL_CON();
            testing.admin_login();
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(MYSQL_CON model)
        {

            var testing = new MYSQL_CON()
            {
                FName = Request.Form["FName"],
                LName = Request.Form["LName"],
                Email = Request.Form["Email"],
                Password = Request.Form["Password"],
                user_Status = Request.Form["user_Status"]
            };
           
            testing.admin_login();

            return View();
        }
        public IActionResult successTest()
        {
            return View();
        }
    }
}