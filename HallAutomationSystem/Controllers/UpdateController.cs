using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Db.DbOperation;
using MyApp.Models;
using MyApp.Db;
using System.Net;

namespace HallAutomationSystem.Controllers
{
    public class UpdateController : Controller
    {
        SearchOperation searchOperation = new SearchOperation();
        AddressInformation addressInformation = null;
        StudentInformation studentInformation = null;
        MealInformation mealInformation = null;
        // GET: Update
        public UpdateController()
        {
            addressInformation = new AddressInformation();
            studentInformation = new StudentInformation();
            mealInformation = new MealInformation();
        }

        // To show the all details of Address for User
        public ActionResult AddresDetails()
        {
            string UserName = (string)Session["UserName"];
            if(UserName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = searchOperation.GetUser(UserName);
            Student student = searchOperation.GetStudent(user.UserId);
            Address address = searchOperation.GetAddress(student.StudentId);
            District PerDistrict = searchOperation.GetDistrict((int)address.P_DistrictId);
            District TempDistrict = searchOperation.GetDistrict((int)address.T_DistrictId);
            AdressUpdateModel adressUpdateModel = new AdressUpdateModel();
            adressUpdateModel.StudentId = address.StudentId;
            adressUpdateModel.Permanent_District_Name = PerDistrict.DistrictName;
            adressUpdateModel.Temporary_District_Name = TempDistrict.DistrictName;
            adressUpdateModel.Permanent_Post_Office = address.P_PostOffice;
            adressUpdateModel.Temporary_Post_Office = address.T_PostOffice;
            adressUpdateModel.Permanent_Village_Name = address.P_VillageName;
            adressUpdateModel.Temporary_Village_Name = address.T_VillageName;
            return View(adressUpdateModel);
        }
        //To Get Data from user  
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdressUpdateModel adressUpdateModel = new AdressUpdateModel();
            adressUpdateModel.StudentId = (int)id;
            return View(adressUpdateModel);
        }
        [HttpPost]
        // Update the data corresponding User Information
        public ActionResult Edit(AdressUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                addressInformation.UpdateAddress(model);
            }
            return RedirectToAction("AddresDetails");
        }

        // To show the all details of Student for User
        public ActionResult StudentDetails()
        {
            string UserName =(string)Session["UserName"];
            if (UserName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Users user = searchOperation.GetUser(UserName);
            Student student = searchOperation.GetStudent(user.UserId);
            Room room = searchOperation.GetRoom((int)student.RoomId);
            DepartmentInfo departmentInfo = searchOperation.GetDepartmentInfo(student.StudentId);
           
            StudentUpdateModel studentUpdateModel = new StudentUpdateModel();
            studentUpdateModel.StudentId = departmentInfo.StudentId;
            studentUpdateModel.StudentName = student.StudentName;
            studentUpdateModel.FatherName = student.FatherName;
            studentUpdateModel.MotherName = student.MotherName;
            studentUpdateModel.MobileNumber = student.MobileNumber;
            studentUpdateModel.RoomNumber = (int)room.RoomNumber;
            return View(studentUpdateModel);
        }

        //To Get data from user
        public ActionResult StudentEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentUpdateModel studentUpdateModel = new StudentUpdateModel();
            studentUpdateModel.StudentId = (int)id;
            return View(studentUpdateModel);
        }

        //Update the data corresponding User Information
        [HttpPost]
        public ActionResult StudentEdit(StudentUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                studentInformation.UpdateStudent(model);
            }
            return RedirectToAction("StudentDetails");
        }

        public ActionResult MealEdit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealUpdateModel mealUpdateModel = new MealUpdateModel();
            mealUpdateModel.MealId = (int)id;
            return View(mealUpdateModel);
        }
        [HttpPost]

        public ActionResult MealEdit(MealUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                int id = mealInformation.UpdateMeal(model);
                if(id > 0)
                {
                    ViewBag.Success = "Meal Updated!";
                    ModelState.Clear();
                }
                else if(id == -1)
                {
                    ViewBag.Success = "Time Is Over!";
                }
                else
                {
                    ViewBag.Success = "Insufficient Balance!";
                }
            }
            return View("MealDetails");
        }

        public ActionResult MealDetails()
        {
            string UserName = (string)Session["UserName"];
            var user = searchOperation.GetUser(UserName);
            var meal = searchOperation.GetMeal(searchOperation.GetStudent(user.UserId).StudentId);
            return View(meal);
        }

  

    }
}