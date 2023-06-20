﻿using HotelApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain.Entities
{
    public class Employee : BaseEntity
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;
        private string _email;
        private string _phone;
        private string _password;

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
