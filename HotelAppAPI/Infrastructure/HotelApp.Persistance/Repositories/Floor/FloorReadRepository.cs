using HotelApp.Application.Repositories;
using HotelApp.Domain.Entities;
using HotelApp.Persistence.Contexts;

namespace HotelApp.Persistence.Repositories
{
    public class FloorReadRepository : ReadRepository<Floor>, IFloorReadRepository
    {
        public FloorReadRepository(SQLServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
