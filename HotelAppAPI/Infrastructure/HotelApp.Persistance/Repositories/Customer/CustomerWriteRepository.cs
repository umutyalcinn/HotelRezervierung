using HotelApp.Application.Repositories;
using HotelApp.Domain.Entities;
using HotelApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(SQLServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
