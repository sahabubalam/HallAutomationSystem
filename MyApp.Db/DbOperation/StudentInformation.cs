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
                var room = context.Rooms.FirstOrDefault(x => x.RoomNumber == RoomNumber);
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
                if (RoomId == 0) /// If Room Number is not valid
                {
                    return 0;
                }
                RoomInformation roomInformation = new RoomInformation();
                roomInformation.UpdateRoom(RoomId, -1);
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
                AccountInformation accountInformation = new AccountInformation();
                accountInformation.AddAccount(UserName, student.StudentId);
                return student.StudentId;
            }

        }

        // Student data update from UpdateController
        public bool UpdateStudent(StudentUpdateModel model)
        {
            using (var context=new HallAutomationSystemEntities())
            {
                var student = context.Student.FirstOrDefault(x => x.StudentId == model.StudentId);
                RoomInformation roomInformation = new RoomInformation();
                roomInformation.UpdateRoom((int)student.RoomId, 1);
                if (student != null)
                {
                    student.StudentName = model.StudentName;
                    student.FatherName = model.FatherName;
                    student.MotherName = model.MotherName;
                    student.MobileNumber = model.MobileNumber;
                    student.RoomId = (int)GetRoomId(model.RoomNumber);
                }
                roomInformation.UpdateRoom((int)student.RoomId, -1);
                context.SaveChanges();
                return true;
            }
        }
    }
}
