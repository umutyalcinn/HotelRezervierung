using HotelApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain.Entities
{
    public class Room : BaseEntity
    {
        private uint _roomNumber;
        private string _roomName;
        private Floor _floor;
        private uint _capacity;
        private decimal _price;

        public uint RoomNumber { get => _roomNumber; set => _roomNumber = value; }
        public string RoomName { get => _roomName; set => _roomName = value; }
        public virtual Floor Floor { get => _floor; set => _floor = value; }
        public uint Capacity { get => _capacity; set => _capacity = value; }
        public decimal Price { get => _price; set => _price = value; }
    }
}
