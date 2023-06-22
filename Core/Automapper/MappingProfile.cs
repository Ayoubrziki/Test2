using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            CreateMap<Flight, FlightDtoModel>()
                .ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.DepartureAirport.Name))
                .ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.ArrivalAirport.Name))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src =>
                string.Format($"{DistanceCalculator.CalculateDistance(src.DepartureAirport.Location.Latitude,
                src.DepartureAirport.Location.Longitude,
                src.ArrivalAirport.Location.Latitude,
                src.ArrivalAirport.Location.Longitude)} KM")));

            CreateMap<FlightDtoModel, Flight>()
                .ForMember(dest => dest.ArrivalAirport, opt => opt.Ignore())
                .ForMember(dest => dest.DepartureAirport, opt => opt.Ignore());

        }
    }
}
