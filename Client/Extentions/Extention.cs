using Business.Airoport;
using Core.Automapper;
using Business.Flight;

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

            //Flight Service
            services.AddTransient<IFlightService, FlightService>();

            //Add Automapper
            services.AddAutoMapper(typeof(Program), typeof(MappingProfile));

            return services;
        }
    }
}
