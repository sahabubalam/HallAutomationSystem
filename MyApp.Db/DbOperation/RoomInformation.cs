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
                context.Rooms.Add(room);
                context.SaveChanges();
                return room.RoomId;
            }
        }
        
        public void UpdateRoom(int RoomNumber , int flag)
        {
            using(var context = new HallAutomationSystemEntities())
            {
                var room = context.Rooms.FirstOrDefault(x => x.RoomId == RoomNumber);
                if(room != null)
                {
                    room.EmptySeat = room.EmptySeat + flag;
                }
                context.SaveChanges();
            }
        }

        
    }
}
