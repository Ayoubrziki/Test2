using Business.Airoport;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class FlightController : Controller
    {
        private readonly IAirportService _airportService;

        public FlightController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
