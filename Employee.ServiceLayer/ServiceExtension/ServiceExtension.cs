using Employee.DBLayer;
using Employee.ServiceLayer.EF.Interface;
using Employee.ServiceLayer.EF.Service;
using Employee.ServiceLayer.Interface;
using Employee.ServiceLayer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWorkRepo>();
            services.AddScoped<IEmployee, ClsEmployee>();
            services.AddScoped<ICake, ClsCake>();

            return services;
        }
    }
}
