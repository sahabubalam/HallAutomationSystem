using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class AccountInformation
    {
        public int AddAccount(string UserName , int StudentId)
        {
            using (var context=new HallAutomationSystemEntities())
            {
                Account account = new Account()
                {
                    StudentId = StudentId,
                    Balance = 0,
                    Due = 0
                };
                context.Account.Add(account);
                context.SaveChanges();
                return account.StudentId;
            }
        }

        public bool UpdateAccount(AccountUpdateModel model)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                AddressInformation addressInformation = new AddressInformation();
                int id = addressInformation.GetStudentId(model.UserName);
                var account = context.Account.FirstOrDefault(x => x.StudentId == id);
                if(account != null)
                {
                    if(account.Due > 0)
                    {
                        int minus = Math.Min((int)account.Due, (int)model.Balance);
                        model.Balance -= minus;
                        account.Due -= minus;
                    }
                    account.Balance += model.Balance;
                }
                context.SaveChanges();
                return true;
            }
        }

        public void decreamentAccountBalance(int StudentId , int taka)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var account = context.Account.FirstOrDefault(x => x.StudentId == StudentId);
                if(account != null)
                {
                    account.Balance -= taka;
                }
                context.SaveChanges();
            }
        }


    }
}
