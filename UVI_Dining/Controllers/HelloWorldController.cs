using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UVI_Dining.Models;
using System.Configuration;
using System.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UVI_Dining.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }


        //FOR THE PROJECT 


            public IActionResult admin_login()
        {
            var testing = new MYSQL_CON();
            testing.admin_login();
            return View();
        }
        [HttpPost]
        public IActionResult admin_login(MYSQL_CON model)
        {

            var testing = new MYSQL_CON() {
            FName = Request.Form["FName"],
            LName = Request.Form["LName"],
            Email = Request.Form["Email"],
            Password = Request.Form["Password"],
            user_Status = Request.Form["user_Status"]
        };
           
          testing.admin_login();
 
            return View();
        }
    }
}
