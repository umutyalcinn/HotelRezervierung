using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain.Entities.Common
{
    public class BaseEntity
    {
        private int _id;
        private DateTime _dateCreated;
        private DateTime _dateLastUpdated;
        private int _lastUpdatedUserID;
        private int _createdUser;

        public int Id { get => _id; set => _id = value; }
        public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }
        public DateTime DateLastUpdated { get => _dateLastUpdated; set => _dateLastUpdated = value; }
        public int LastUpdatedUserID { get => _lastUpdatedUserID; set => _lastUpdatedUserID = value; }
        public int CreatedUser { get => _createdUser; set => _createdUser = value; }
    }
}
