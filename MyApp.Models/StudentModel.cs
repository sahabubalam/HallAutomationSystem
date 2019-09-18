using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class StudentModel
    {
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int RoomNumber { get; set; }
        public string MobileNumber { get; set; }
    }
    public class StudentUpdateModel : StudentModel
    {
        public int StudentId { get; set; }
    }
}
