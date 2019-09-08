using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class DepartmentInformation
    {
        public int AddDepartmentName(DepartmentModel model)
        {
            using (var context=new HallAutomationSystemEntities())
            {
                Department department = new Department()
                {
                    DeptName = model.DepartmentName
                };

                context.Department.Add(department);
                context.SaveChanges();
                return department.DeptId;

            }

        }
    }
}
