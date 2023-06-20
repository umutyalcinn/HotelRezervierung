using HotelApp.Application.Repositories;
using HotelApp.Domain.Entities;
using HotelApp.Persistence.Contexts;

namespace HotelApp.Persistence.Repositories
{
    internal class RezervationReadRepository : ReadRepository<Rezervation>, IRezervationReadRepository
    {
        public RezervationReadRepository(SQLServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
