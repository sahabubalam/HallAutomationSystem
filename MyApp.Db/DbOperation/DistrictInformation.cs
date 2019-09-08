using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class DistrictInformation
    {
        public int AddDistrict(DistrictModel model)
        {
            using (var context=new HallAutomationSystemEntities())
            {
                District district = new District()
                {
                    DistrictName = model.DistrictName
                };
                context.District.Add(district);
                context.SaveChanges();
                return district.DistrictId;
            }

        }
    }
}
