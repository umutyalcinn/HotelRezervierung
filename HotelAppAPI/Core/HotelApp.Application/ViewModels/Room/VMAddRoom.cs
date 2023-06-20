using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.ViewModels.Room
{
    public class VMAddRoom
    {
        public uint RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int FloorId { get; set; }
        public decimal Price { get; set; }
        public uint Capacity { get; set; }
    }
}
