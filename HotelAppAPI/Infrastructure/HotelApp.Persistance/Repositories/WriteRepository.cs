using HotelApp.Application.Repositories;
using HotelApp.Domain.Entities.Common;
using HotelApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly SQLServerDbContext _dbContext;

        public WriteRepository(SQLServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddRangeAsync(ICollection<T> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public async Task<bool> AddAsync(T model)
        {
            var entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public bool Remove(T model)
        {
            var entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            return Remove(entity);
        }

        public bool Update(T model)
        {
            var entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
