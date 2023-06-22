using Business.Airoport;
using Business.Flight;
using Domain.Dto;
using Domain.Exception;
using Domain.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

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

        public async Task<IActionResult> FlightList()
        {
            var model = await _flightService.GetAllAsync();
            return View("List", model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var lAirports = await _airportService.GetAllAsync();

            var model = new FlightDtoModel
            {
                DepartureAirports = lAirports.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList(),
                ArrivalAirports = lAirports.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlightDtoModel model)
        {
            var validatorResult = new FlightValidator().Validate(model);
            if (!validatorResult.IsValid)
            {
                var lAirports = await _airportService.GetAllAsync();
                foreach (var failure in validatorResult.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName
                        , failure.ErrorMessage);
                }

                model.DepartureAirports = lAirports.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                model.ArrivalAirports = lAirports.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                return View(model);
            }
            await _flightService.InsertAsync(model);
            return RedirectToAction(nameof(FlightList));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var model = await _flightService.GetByIdAsync(Id);
            var lAiroports = await _airportService.GetAllAsync();

            model.DepartureAirports = lAiroports.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            model.ArrivalAirports = lAiroports.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlightDtoModel model)
        {
            var validatorResult = new FlightValidator().Validate(model);
            if (!validatorResult.IsValid)
            {
                var lAirports = await _airportService.GetAllAsync();
                foreach (var failure in validatorResult.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName
                        , failure.ErrorMessage);
                }

                model.DepartureAirports = lAirports.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                model.ArrivalAirports = lAirports.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                return View(model);
            }
            await _flightService.UpdateAsync(model);
            return RedirectToAction(nameof(FlightList));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int pFilghtId)
        {
            await _flightService.DeleteAsync(pFilghtId);
            return RedirectToAction(nameof(FlightList));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel model)
        {
            return View(model);
        }
    }
}
