using Business.Airoport;
using Core.Automapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Web.Extentions
{
    public static class Extention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,ConfigurationManager configuration)
        {
            //Add DbContext
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString(name: "SqlConnectionString"));
            });

            //Inject Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Airport Service
            services.AddTransient<IAirportService, AirportService>();

            //Add Automapper
            services.AddAutoMapper(typeof(Program), typeof(MappingProfile));

            return services;
        }
    }
}
