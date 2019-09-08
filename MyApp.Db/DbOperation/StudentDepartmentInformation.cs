using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class StudentDepartmentInformation
    {
        public int GetStudentId(string UserName)
        {
            StudentInformation temp = new StudentInformation();
            int UserId = temp.GetUserId(UserName);
            using (var context = new HallAutomationSystemEntities())
            {
                var student = context.Student.FirstOrDefault(x => x.UserId == UserId);
                if (student != null)
                {
                    return student.StudentId;
                }
                else return 0;
            }

        }
        public int GetDepartmentId(string DeptName)
        {
            using (var context = new HallAutomationSystemEntities())
            {
                var department = context.Department.FirstOrDefault(x => x.DeptName ==DeptName);
                if (department != null)
                {
                    return department.DeptId;
                }
                else return 0;
            }
        }
        public int AddStudentDepartmentInformation(StudentDepartmentInformationModel model,string UserName)
        {
            using (var context=new HallAutomationSystemEntities())
            {
                int Dept_Name = GetDepartmentId(model.Department_name);
                if (Dept_Name == 0)
                {
                    return 0;
                }
                DepartmentInfo departmentInfo = new DepartmentInfo()
                {
                    DepartmentId= Dept_Name,
                    StudentId = GetStudentId(UserName),
                    Session = model.Session,
                    Cgpa = model.Cgpa
                };
                context.DepartmentInfo.Add(departmentInfo);
                context.SaveChanges();
                return departmentInfo.StudentId;
            }

        }
    }
}
