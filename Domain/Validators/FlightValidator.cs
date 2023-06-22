using Domain.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class FlightValidator : AbstractValidator<FlightDtoModel>
    {
        public FlightValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Flight name cannot be empty.");
            RuleFor(x => x.DepartureAirportId).NotEmpty().WithMessage("Select departure airport.");
            RuleFor(x => x.ArrivalAirportId).NotEmpty().WithMessage("Select arrival airport.");
        }
    }
}
