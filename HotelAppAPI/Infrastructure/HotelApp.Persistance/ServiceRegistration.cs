using HotelApp.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HotelApp.Persistence.Repositories;
using HotelApp.Application.Repositories;
using HotelApp.Domain.Entities;

namespace HotelApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<SQLServerDbContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.SQLServerConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
            services.AddScoped<IRoomReadRepository, RoomReadRepository>();
            services.AddScoped<IRoomWriteRepository, RoomWriteRepository>();
            services.AddScoped<IFloorWriteRepository, FloorWriteRepository>();
            services.AddScoped<IFloorReadRepository, FloorReadRepository>();
            services.AddScoped<IRezervationWriteRepository, RezervationWriteRepository>();
            services.AddScoped<IRezervationReadRepository, RezervationReadRepository>();
        }
    }
}
