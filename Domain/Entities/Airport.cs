using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Airport : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int LocationId { get; set; }

        public virtual GPSLocation Location { get; set; }
        public virtual IEnumerable<Flight> DepartureAirportFlights { get; set; }
        public virtual IEnumerable<Flight> ArrivalAirportFlights { get; set; }

    }
}
