using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class MealModel
    {
        public int Lunch { get; set; }
        public int Dinnar { get; set; }
    }
    public class MealUpdateModel : MealModel
    {
        public int MealId { get; set; }
    }
}
