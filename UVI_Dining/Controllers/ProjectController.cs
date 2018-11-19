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
        public IActionResult login(logVal model)
        {
            var logVal = new logVal()
            {
                Email = model.Email,
                Password = model.Password,

            };


            if (logVal.UserExists())
            {
                return View("successtest", logVal);
            }
            else
            {
                return View("login");
            };


        }
        //FOR THE PROJECT 
        public IActionResult SignUp()
        {
            //  var testing = new LogValidator();
            //testing.admin_login();
            var worknuh = new logVal();
            worknuh.Admin_login();
            return View();
        }
        [HttpPost]
        //public IActionResult SignUp(LogValidator model)
        public IActionResult SignUo(logVal model)
        {

            var worknuh = new logVal()
            {
                FName = Request.Form["FName"],
                LName = Request.Form["LName"],
                Email = Request.Form["Email"],
                Password = Request.Form["Password"],
                user_Status = Request.Form["user_Status"]
                //  campus_loc = Request.Form["campus_loc"]
            };

            worknuh.Admin_login();

            return View();
        }


        public IActionResult successTest()
        {
            return View();
        }


    }
}