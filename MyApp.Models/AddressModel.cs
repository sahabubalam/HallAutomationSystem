using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class AddressModel
    {
        public string Permanent_District_Name { get; set; }
        public string Permanent_Post_Office { get; set; }
        public string Permanent_Village_Name { get; set; }
        public string Temporary_District_Name { get; set; }
        public string Temporary_Post_Office { get; set; }
        public string Temporary_Village_Name { get; set; }
    }
}
