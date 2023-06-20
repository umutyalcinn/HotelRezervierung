using HotelApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain.Entities
{
    public class Rezervation : BaseEntity
    {
        private Customer _customer;
        private Room _room;
        private DateTime _startDate;
        private DateTime _endDate;

        public virtual Customer Customer { get => _customer; set => _customer = value; }
        public virtual Room Room { get => _room; set => _room = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
    }
}
