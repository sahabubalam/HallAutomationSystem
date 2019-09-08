using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperation
{
    public class RoomInformation
    {
        //To add room information
        public int AddRoom(RoomModel model)
        {
            using (var context=new HallAutomationSystemEntities())
            {
                Room room = new Room()
                {
                    RoomNumber = model.RoomNumber,
                    TotalSeat = model.TotalSeat,
                    EmptySeat = model.EmptySeat
                };
                context.Room.Add(room);
                context.SaveChanges();
                return room.RoomId;
            }
        }
        

        
    }
}
