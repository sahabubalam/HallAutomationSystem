using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyApp.Db;
using MyApp.Db.DbOperation;
using MyApp.Models;


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

        public ActionResult Profile()
        {
            string UserName = (string)Session["UserName"];
            if(UserName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchOperation searchOperation = new SearchOperation();
            Users user = searchOperation.GetUser(UserName);
            Student student = searchOperation.GetStudent(user.UserId);
            Address address = searchOperation.GetAddress(student.StudentId);
            District parDistrict = searchOperation.GetDistrict((int)address.P_DistrictId);
            District TemDistrict = searchOperation.GetDistrict((int)address.T_DistrictId);
            DepartmentInfo departmentInfo = searchOperation.GetDepartmentInfo(student.StudentId);
            Department department = searchOperation.GetDepartment((int)departmentInfo.DepartmentId);
            Room room = searchOperation.GetRoom((int)student.RoomId);
            UserProfileModel userProfileModel = new UserProfileModel();
            userProfileModel.StudentName = student.StudentName;
            userProfileModel.FatherName = student.FatherName;
            userProfileModel.MotherName = student.MotherName;
            userProfileModel.MobileNumber = student.MobileNumber;
            userProfileModel.ParmanentDistrict = parDistrict.DistrictName;
            userProfileModel.ParmanentPostOfiice = address.P_PostOffice;
            userProfileModel.ParmanentVillage = address.P_VillageName;
            userProfileModel.TemporaryDistrict = TemDistrict.DistrictName;
            userProfileModel.TemporaryPostOfiice = address.T_PostOffice;
            userProfileModel.TemporaryVillage = address.T_VillageName;
            userProfileModel.DepartmentName = department.DeptName;
            userProfileModel.Session = departmentInfo.Session;
            userProfileModel.Cgpa = departmentInfo.Cgpa;
            userProfileModel.RoomNumber = (int)room.RoomNumber;
            return View(userProfileModel);
        }
    }
}