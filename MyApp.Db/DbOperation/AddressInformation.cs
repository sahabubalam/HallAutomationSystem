using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class AddressInformation
    {
        /// <summary>
        /// To get StudentId From student table by using UserName
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int GetStudentId(string UserName)
        {
            StudentInformation temp = new StudentInformation();
            int UserId = temp.GetUserId(UserName);
            using(var context = new HallAutomationSystemEntities())
            {
                var student = context.Student.FirstOrDefault(x => x.UserId == UserId);
                if (student != null)
                {
                    return student.StudentId;
                }
                else return 0;
            }
            
        }
        /// <summary>
        /// To Get District Id by Using District Name
        /// </summary>
        /// <param name="DistrictName"></param>
        /// <returns>District Id</returns>
        public int GetDistrictId(string DistrictName)
        {
            using(var context=new HallAutomationSystemEntities())
            {
                var district = context.District.FirstOrDefault(x => x.DistrictName == DistrictName);
                if (district != null)
                {
                    return district.DistrictId;
                }
                else return 0;
            }
        }
        public int AddAddress(AddressModel model , string UserName)
        {
            using (var context=new HallAutomationSystemEntities())
            {
                int DistId1 = GetDistrictId(model.Permanent_District_Name);
                int DistId2 = GetDistrictId(model.Temporary_District_Name);
                if(DistId1 == 0 || DistId2 == 0)
                {
                    return 0;
                }
                Address address = new Address()
                {
                    P_DistrictId = DistId1,
                    T_DistrictId = DistId2,
                    P_VillageName = model.Permanent_Village_Name,
                    P_PostOffice = model.Permanent_Post_Office,
                    T_VillageName = model.Temporary_Village_Name,
                    T_PostOffice = model.Temporary_Post_Office,
                    StudentId = GetStudentId(UserName)
                };
                context.Address.Add(address);
                context.SaveChanges();
                return address.StudentId;
            }
        }
        //Address Update from UpdateController
        public bool UpdateAddress(AdressUpdateModel model)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var address = context.Address.FirstOrDefault(x => x.StudentId == model.StudentId);
                if(address != null)
                {
                    address.P_DistrictId = GetDistrictId(model.Permanent_District_Name);
                    address.P_PostOffice = model.Permanent_Post_Office;
                    address.P_VillageName = model.Permanent_Village_Name;
                    address.T_DistrictId = GetDistrictId(model.Temporary_District_Name);
                    address.T_PostOffice = model.Temporary_Post_Office;
                    address.T_VillageName = model.Temporary_Village_Name;
                }
                context.SaveChanges();
                return true;
            }
            
        }
    }
}
