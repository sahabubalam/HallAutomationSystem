using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyApp.Db;



namespace HallAutomationSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                ViewBag.Name = Session["UserName"];
            }
            else ViewBag.Name = "Hobe na";
            return View();
        }
        public ActionResult About()
        {
           

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}