using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Db;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class StudentInformation
    {
        // To get the Room Id by using Room Number.
        public int GetRoomId(int RoomNumber)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var room = context.Room.FirstOrDefault(x => x.RoomNumber == RoomNumber);
                if(room != null)
                {
                    return room.RoomId;
                }
                else return 0;
            }
            
        }
        // To get the User Id by using User Name from Session 
        public int GetUserId(string UserName)
        {
            using (var context = new HallAutomationSystemEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == UserName);
                if (user != null)
                {
                    return user.UserId;
                }
                else return 0;
            }
        }
        // To Add The User Personal Information into Student Table
        public int AddStudentPersonalInfo(StudentModel model , string UserName)
        {
            using(var context=new HallAutomationSystemEntities())
            {
                int RoomId = GetRoomId(model.RoomNumber);
                if(RoomId == 0) /// If Room Number is not valid
                {
                    return 0;
                }
                Student student = new Student()
                {
                    StudentName = model.StudentName,
                    FatherName = model.FatherName,
                    MotherName = model.MotherName,
                    MobileNumber = model.MobileNumber,
                    RoomId = RoomId,
                    UserId = GetUserId(UserName)
                };
                context.Student.Add(student);
                context.SaveChanges();
                return student.StudentId;
            }

        }
    }
}
