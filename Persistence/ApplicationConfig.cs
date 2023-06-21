using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static void InstallDatabaseIfNotExist(DataContext _context)
        {
            if (_context.Database.GetPendingMigrations().Any()) 
                _context.Database.Migrate();
        }

        public static async Task SeedData(DataContext _context)
        {
            if (!_context.Airport.Any())
            {
                List<Airport> airportList = new List<Airport>
            {
                new Airport
                {
                    Name = "Aéroport Mohammed V de Casablanca",
                    Code = "CMN",
                    Location = new GPSLocation(33.3675, -7.589972)
                },
                new Airport
                {
                    Name = "Aéroport Marrakech-Ménara",
                    Code = "RAK",
                    Location = new GPSLocation(31.6069, -8.0363)
                },
                new Airport
                {
                    Name = "Aéroport Agadir-Al Massira",
                    Code = "AGA",
                    Location = new GPSLocation(30.3250, -9.4131)
                }
            };

                await _context.Airport.AddRangeAsync(airportList);
            }

            await _context.SaveChangesAsync();
        }
    }
}
