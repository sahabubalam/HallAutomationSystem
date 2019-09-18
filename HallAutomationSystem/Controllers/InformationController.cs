using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Db;
using MyApp.Models;
using MyApp.Db.DbOperation;

namespace HallAutomationSystem.Controllers
{
    [Authorize]
    public class InformationController : Controller
    {
        StudentInformation studentInformation = null;
        RoomInformation roomInformation = null;
        DistrictInformation districtInformation = null;
        AddressInformation addressInformation = null;
        DepartmentInformation departmentInformation = null;
        StudentDepartmentInformation studentDepartmentInformation = null;
        MealInformation mealInformation = null;
        AccountInformation accountInformation = null;
        // GET: Information
        public InformationController()
        {
            studentInformation = new StudentInformation();
            roomInformation = new RoomInformation();
            districtInformation = new DistrictInformation();
            addressInformation = new AddressInformation();
            departmentInformation = new DepartmentInformation();
            studentDepartmentInformation = new StudentDepartmentInformation();
            mealInformation = new MealInformation();
            accountInformation = new AccountInformation();
        }
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Student(StudentModel model)
        {
            string UserName = (string)(Session["UserName"]);
            if (ModelState.IsValid)
            {
                int id = studentInformation.AddStudentPersonalInfo(model , UserName);
                if(id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Data Inserted!";
                }
            }
            return View();
        }
        //Room Information 
        public ActionResult Rooms()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Rooms(RoomModel model)
        {
            if (ModelState.IsValid)
            {
                int id = roomInformation.AddRoom(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Data inserted";
                }
            }
            return View();
        }
        //Add District Name
        public ActionResult Districts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Districts(DistrictModel model)
        {
            if (ModelState.IsValid)
            {
                int id = districtInformation.AddDistrict(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Data inserted";
                }
            }
            return View();
        }
        public ActionResult Addresses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addresses(AddressModel model)
        {
            string UserName = (string)(Session["UserName"]);
            if (ModelState.IsValid)
            {
                int id = addressInformation.AddAddress(model, UserName);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Data Inserted Succesfully!";
                }
                else ViewBag.Success = "Information Invalid!";
            }
            return View();
        }
        //Add Department Name
        public ActionResult Departments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Departments(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                int id = departmentInformation.AddDepartmentName(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Data inserted";
                }
            }
            return View();
        }
        //Add Department information
        public ActionResult StudentDepartmentInformation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentDepartmentInformation(StudentDepartmentInformationModel model)
        {
            string UserName = (string)(Session["UserName"]);
            if (ModelState.IsValid)
            {
                int id = studentDepartmentInformation.AddStudentDepartmentInformation(model, UserName);
                if(id > 0)
                {

                    ModelState.Clear();
                    ViewBag.Success = "Data inserted";
                }
            }
            return View();
        }
        public ActionResult Meals()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Meals(MealModel model)
        {
            string UserName = (string)(Session["UserName"]);
            if (ModelState.IsValid)
            {
                int id = mealInformation.AddMeal(model,UserName);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Data inserted";
                }
            }
            return View();
        }
        
        //public ActionResult Accounts()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Accounts(AccountModel model)
        //{
        //    string UserName = (string)(Session["UserName"]);
        //    if (ModelState.IsValid)
        //    {
        //        int id = accountInformation.AddAccount(model, UserName);
        //        if (id > 0)
        //        {
        //            ModelState.Clear();
        //            ViewBag.Success = "Data inserted";
        //        }
        //    }
        //    return View();
        //}
        
    }
}