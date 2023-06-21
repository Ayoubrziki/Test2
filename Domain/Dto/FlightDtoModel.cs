using Domain.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class FlightDtoModel
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Departure Airport")]
        public int DepartureAirportId { get; set; }
        [DisplayName("Departure Airport")]
        public int ArrivalAirportId { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        public IList<SelectListItem> DepartureAirports { get; set; }
        public IList<SelectListItem> ArrivalAirports { get; set; }
    }
}
