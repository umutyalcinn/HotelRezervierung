using HotelApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Persistence
{
    internal class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<SQLServerDbContext>
    {
        public SQLServerDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SQLServerDbContext> builder = new();
            builder.UseSqlServer(Configuration.SQLServerConnectionString);
            return new(builder.Options);
        }
    }
}
