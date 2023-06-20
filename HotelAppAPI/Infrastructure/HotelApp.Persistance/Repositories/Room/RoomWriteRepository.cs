using HotelApp.Application.Repositories;
using HotelApp.Domain.Entities;
using HotelApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Persistence.Repositories
{
    public class RoomWriteRepository : WriteRepository<Room>, IRoomWriteRepository
    {
        public RoomWriteRepository(SQLServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
