using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Airport
            CreateMap<Airport, AirportDtoModel>();
            CreateMap<GPSLocation, GPSLocationDtoModel>();

            //Flight
            CreateMap<Flight, FlightDtoModel>();
            CreateMap<FlightDtoModel, Flight>();

        }
    }
}
