using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using UVI_Dining.Models;


namespace UVI_Dining.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult login(logVal model)
        {
            var logVal = new logVal()
            {
                Email = model.Email,
                Password = model.Password,

            };


            if (logVal.UserExists())
            {
                Session["FName"] = logVal.FName;
                Session["user_Status"] = logVal.user_Status;
                Session["campus_loc"] = logVal.campus_loc;
                Session["campus_id"] = logVal.campus_id;
                return View("successtest", logVal);
            }
            else
            {
                return View("login");
            };


        }
        //FOR THE PROJECT 
        public ActionResult SignUp()
        {

            return View();
        }
        [HttpPost]
        //public ActionResult SignUp(LogValidator model)
        public ActionResult SignUp(logVal model)
        {

            var worknuh = new logVal()
            {
                FName = Request.Form["FName"],
                LName = Request.Form["LName"],
                Email = Request.Form["Email"],
                Password = Request.Form["Password"],
                user_Status = Request.Form["user_Status"],
                campus_id = int.Parse(Request.Form["campus"])

                //  campus_loc = Request.Form["campus_loc"]
            };

            worknuh.Admin_login();

            return View();
        }


        public ActionResult successTest()
        {
          
            return View();
        }

        public ActionResult menu()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }

        public ActionResult aboutus()
        {
            return View();
        }
        public ActionResult location()
        {
            return View();
        }
        public ActionResult hours()
        {
            return View();
        }
        //Foods
        public ActionResult Foods(logVal model)
        {
            var l = new logVal();
            l.campus_id = int.Parse(Session["campus_id"].ToString());
            ViewBag.Foods = l.GetFood();
            return View();
        }



    }
}