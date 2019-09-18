using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class AccountModel
    {
        public int Balance { get; set; }
        public int Due { get; set; }
    }
    public class AccountUpdateModel : AccountModel
    {
        public string UserName { get; set; }
    }
}
