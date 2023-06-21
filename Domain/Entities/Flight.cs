namespace Domain.Entities
{
    public class Flight : BaseEntity
    {
        public string Name { get; set; }
        public int? DepartureAirportId { get; set; }
        public int? ArrivalAirportId { get; set; }

        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport ArrivalAirport { get; set; }
    }
}
