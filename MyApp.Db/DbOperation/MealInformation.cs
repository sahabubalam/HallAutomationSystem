using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class MealInformation
    {
        AddressInformation temp = new AddressInformation();
        SearchOperation searchOperation = new SearchOperation();
        AccountInformation accountInformation = new AccountInformation();
        public int AddMeal(MealModel model, string UserName)
        {
            var user = searchOperation.GetUser(UserName);
            var student = searchOperation.GetStudent(user.UserId);
            var room = searchOperation.GetRoom((int)student.RoomId);
            using(var context = new HallAutomationSystemEntities())
            {
                var meal = context.Meal.FirstOrDefault(x => x.StudentId == student.StudentId); 
                if(meal != null)
                {
                    return -3;
                }
            }
            TimeSpan now = DateTime.Now.TimeOfDay;
            TimeSpan start = new TimeSpan(00, 0, 0);
            TimeSpan End = new TimeSpan(24, 00, 0);
            if(!(now >= start && now <= End))
            {
                return -1;
            }
            Account account = searchOperation.GetAccount(student.StudentId);
            int taka = searchOperation.GetMealCost();
            int meal_cost = (model.Dinnar * taka + model.Lunch * taka);
            if(meal_cost > account.Balance)
            {
                return -2;
            }
            else
            {
                accountInformation.decreamentAccountBalance(student.StudentId,meal_cost);
            }
            using (var context=new HallAutomationSystemEntities())
            {

                Meal meal = new Meal()
                {
                    StudentId = student.StudentId,
                    RoomNo = room.RoomNumber,
                    Dinnar = model.Dinnar,
                    Lunch = model.Lunch,
                    Time = DateTime.Now.TimeOfDay,
                    Date = DateTime.Today,
                    StudentName = student.StudentName 
                };
                context.Meal.Add(meal);
                context.SaveChanges();
                return meal.MealId;
            }
        }

        public int UpdateMeal(MealUpdateModel model)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var meal = context.Meal.FirstOrDefault(x => x.MealId == model.MealId && x.Date == DateTime.Today);
                if(meal == null)
                {
                    return -3;
                }
                TimeSpan now = DateTime.Now.TimeOfDay;
                TimeSpan start = new TimeSpan(00, 0, 0);
                TimeSpan End = new TimeSpan(24, 00, 0);
                if (!(now >= start && now <= End))
                {
                    return -1;
                }

                int taka = searchOperation.GetMealCost();
                int meal_cost = (meal.Dinnar * taka + meal.Lunch * taka);
                accountInformation.decreamentAccountBalance((int)meal.StudentId, (-1)*meal_cost);
                int New_Meal_Cost = (model.Dinnar * taka + model.Lunch * taka);
                Account account = searchOperation.GetAccount((int)meal.StudentId);
                if(New_Meal_Cost > account.Balance)
                {
                    return -2;
                }
                meal.Lunch = model.Lunch;
                meal.Dinnar = model.Dinnar;
                context.SaveChanges();
                return meal.MealId;
            }
           
        }

    }



}
