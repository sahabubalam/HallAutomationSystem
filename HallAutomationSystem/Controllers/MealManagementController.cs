using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using MyApp.Db.DbOperation;
using MyApp.Db;

namespace HallAutomationSystem.Controllers
{
    public class MealManagementController : Controller
    {
        // GET: MealManagement
        AccountInformation accountInformation = null;
        MealInformation mealInformation = null;
        SearchOperation searchOperation = null;
        public MealManagementController()
        {
            accountInformation = new AccountInformation();
            mealInformation = new MealInformation();
            searchOperation = new SearchOperation();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Account(AccountUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                accountInformation.UpdateAccount(model);
            }
            return View();
        }

        public ActionResult AddMeal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMeal(MealModel model)
        {
            string UserName = (string)Session["UserName"];
            if (ModelState.IsValid)
            {
                int id = mealInformation.AddMeal(model, UserName);
                if(id > 0)
                {
                    ViewBag.Success = "Meal Added";
                    ModelState.Clear();
                }
                else if(id == -1)
                {
                    ViewBag.Success = "Time Is Over";
                }
                else if(id == -3)
                {
                    ViewBag.Success = "You already added meal You can just update it";
                }
                else if(id == -2)
                {
                    ViewBag.Success = "Insufficient Balance!";
                }
            }
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }
        public ActionResult AllMealDetails()
        {
            List<Meal> meals = searchOperation.GetAllMeals();
            var meal = meals.OrderBy(x => x.RoomNo);
            var MealRate = searchOperation.GetMealCost();
            ViewBag.MealRate = MealRate;
            return View(meal);
        }

    }
}