using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Db;
using MyApp.Models;
using MyApp.Db.DbOperation;
using System.Web.Security;

namespace HallAutomationSystem.Controllers
{
    public class AccountController : Controller
    {
        UserRegistration RegistraitionRepository = null;
        UserLogin LoginRepository = null;
        // GET: Account
        public AccountController()
        {
            RegistraitionRepository = new UserRegistration();
            LoginRepository = new UserLogin();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                int id = RegistraitionRepository.Operation(model);
                if(id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Data Added";
                }
                else
                {
                    ViewBag.Success = "Data is not Added";
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (LoginRepository.LoginOperation(model))
                {
                    ViewBag.Failed = "Success";
                    Session["UserName"] = model.UserName; 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Failed = "Invalid Username or Password";
                }
            }
           
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}