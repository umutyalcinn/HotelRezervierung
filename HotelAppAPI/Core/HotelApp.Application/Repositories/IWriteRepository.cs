using HotelApp.Domain.Entities;
using HotelApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T: BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(ICollection<T> model);
        bool Remove(T model);
        Task<bool> RemoveAsync(int id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
