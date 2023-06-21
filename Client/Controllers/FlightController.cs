using Business.Airoport;
using Business.Flight;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class FlightController : Controller
    {
        private readonly IAirportService _airportService;
        private readonly IFlightService _flightService;

        public FlightController(IAirportService airportService, 
            IFlightService flightService)
        {
            _airportService = airportService;
            _flightService = flightService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
