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
        public int AddMeal(MealModel model,string UserName)
        {
            AddressInformation temp = new AddressInformation();
            using (var context=new HallAutomationSystemEntities())
            {
                Meal meal = new Meal()
                {
                    StudentId = temp.GetStudentId(UserName),
                    Dinnar=model.Dinnar,
                    Lunch=model.Lunch

                };
                context.Meal.Add(meal);
                context.SaveChanges();
                return meal.MealId;
            }
        }
    }
}
