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
        public int AddAccount(AccountModel model,string UserName)
        {
            AddressInformation temp = new AddressInformation();
            using (var context=new HallAutomationSystemEntities())
            {
                Account account = new Account()
                {
                    StudentId = temp.GetStudentId(UserName),
                    Balance = model.Balance,
                    Due = model.Due
                };
                context.Account.Add(account);
                context.SaveChanges();
                return account.StudentId;
            }
        }
    }
}
