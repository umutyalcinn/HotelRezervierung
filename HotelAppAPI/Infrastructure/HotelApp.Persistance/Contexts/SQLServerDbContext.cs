using HotelApp.Domain.Entities;
using HotelApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Persistence.Contexts
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext(DbContextOptions options) : base(options)
        {  }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = this.ChangeTracker.Entries<BaseEntity>();

            foreach(var item in datas)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.DateCreated = DateTime.Now;
                        item.Entity.DateLastUpdated = DateTime.Now;
                        item.Entity.LastUpdatedUserID = 0;
                        item.Entity.CreatedUser = 0;
                        break;
                    case EntityState.Modified:
                        item.Entity.DateLastUpdated = DateTime.Now;
                        item.Entity.LastUpdatedUserID = 0;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
