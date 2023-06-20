using HotelApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HotelApp.Persistence.Contexts;

namespace HotelApp.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly SQLServerDbContext _dbContext;

        public ReadRepository(SQLServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }
    }
}
