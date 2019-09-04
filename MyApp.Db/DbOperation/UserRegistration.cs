using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class UserRegistration
    {

        public int HashFunction(string str)
        {
            long Base = 127, Mod = 1000000007;
            long ans = 0;
            int len = str.Length;
            long pow = 1;
            for(int i = 0; i<len; i++)
            {
                ans = (ans + str[i] * pow) % Mod;
                pow = (pow * Base) % Mod;
            }
            return (int)ans;
        }

        public int Operation(RegistrationModel model)
        {
            using(var context =new HallAutomationSystemEntities())
            {
                Users user = new Users()
                {
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Password = HashFunction(model.Password)

                };
                context.Users.Add(user);
                context.SaveChanges();
                return user.UserId;
            }
        }
    }
}
