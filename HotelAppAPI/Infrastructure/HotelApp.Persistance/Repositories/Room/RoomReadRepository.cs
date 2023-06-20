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
    public class RoomReadRepository : ReadRepository<Room>, IRoomReadRepository
    {
        public RoomReadRepository(SQLServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
