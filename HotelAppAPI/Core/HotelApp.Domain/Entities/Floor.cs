using HotelApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelApp.Domain.Entities
{
    public class Floor : BaseEntity
    {
        uint _floorNumber;

        string _floorName;

        [JsonIgnore]
        private ICollection<Room> _rooms;

        public virtual ICollection<Room> Rooms { get => _rooms; set => _rooms = value; }
        public uint FloorNumber { get => _floorNumber; set => _floorNumber = value; }
        public string FloorName { get => _floorName; set => _floorName = value; }
    }
}
