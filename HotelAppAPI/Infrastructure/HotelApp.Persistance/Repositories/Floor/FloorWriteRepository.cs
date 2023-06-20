using HotelApp.Application.Repositories;
using HotelApp.Domain.Entities;
using HotelApp.Persistence.Contexts;

namespace HotelApp.Persistence.Repositories
{
    internal class FloorWriteRepository : WriteRepository<Floor>, IFloorWriteRepository
    {
        public FloorWriteRepository(SQLServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
