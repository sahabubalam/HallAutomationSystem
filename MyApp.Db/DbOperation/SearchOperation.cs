using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class SearchOperation
    {

        // Get a row from Users table by using UserName
        public Users User(string UserName)
        {
            using(var context=new HallAutomationSystemEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == UserName);
                if (user != null)
                    return user;

                else
                {
                    user.UserId = -1;
                    return user;
                }
               
            }
        }
        // Get a row from Student table by using UserId
        public Student Student(int UserId)
        {
           using(var context = new HallAutomationSystemEntities())
            {
                var student = context.Student.FirstOrDefault(x => x.UserId == UserId);
                if(student != null)
                {
                    return student;
                }
                else
                {
                    student.StudentId = -1;
                    return student;
                }
            } 
        }
        // Get a row from DepartmentInfo table by using StudentId
        public DepartmentInfo GetDepartmentInfo(int StudentId)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var departmentinfo = context.DepartmentInfo.FirstOrDefault(x => x.StudentId == StudentId);
                if(departmentinfo != null)
                {
                    return departmentinfo;
                }
                else
                {
                    departmentinfo.DepartmentId = -1;
                    return departmentinfo;
                }
            }
        }
        // Get a row from Department table by using DepartmentId
        public Department GetDepartment(int DepartmentId)
        {
            using (var context = new HallAutomationSystemEntities())
            {
                var department = context.Department.FirstOrDefault(x => x.DeptId == DepartmentId);
                if(department != null)
                {
                    return department;
                }
                else
                {
                    department.DeptId = -1;
                    return department;
                }
            }
        }
        // Get a row from Address table by using StudentId
        public Address GetAddress(int StudentId)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var address = context.Address.FirstOrDefault(x => x.StudentId == StudentId);
                if(address != null)
                {
                    return address;
                }
                else
                {
                    address.StudentId = -1;
                    return address;
                }
            }
        }
        // Get a row from District Table by using District Id
        public District GetDistrict(int Districtid)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var district = context.District.FirstOrDefault(x => x.DistrictId == Districtid);
                if(district != null)
                {
                    return district;
                }
                else
                {
                    district.DistrictId = -1;
                    return district;
                }
            }
        }
        // Get a row from Room table by using RoomId
        public Room GetRoom(int RoomId)
        {
            using (var context = new HallAutomationSystemEntities())
            {
                var room = context.Room.FirstOrDefault(x => x.RoomId == RoomId);
                if (room != null)
                {
                    return room;
                }
                else
                {
                    room.RoomId = -1;
                    return room;
                }
            }
        }
        // Get a row from meal table by using StudentId
        public Meal GetMeal(int StudentId)
        {
            using (var context=new HallAutomationSystemEntities())
            {
                var meal = context.Meal.FirstOrDefault(x => x.StudentId == StudentId);
                if (meal != null)
                {
                    return meal;
                }
                else
                {
                    meal.StudentId = -1;
                    return meal;
                }
            }
        }
    }
}
