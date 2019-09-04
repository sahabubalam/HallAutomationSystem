using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class UserLogin
    {
        UserRegistration emp = new UserRegistration();
        public bool LoginOperation(LoginModel model)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == model.UserName);
                int password = emp.HashFunction(model.Password);
                if (password == user.Password)
                {
                    return true;
                }
                else return false;
            }
        }
    }
}
