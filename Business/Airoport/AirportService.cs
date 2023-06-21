using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Airoport
{
    public class AirportService : IAirportService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Airport> _airportRepository;

        public AirportService(IMapper mapper,
            IRepository<Airport> airportRepository)
        {
            _mapper = mapper;
            _airportRepository = airportRepository;
        }

        public async Task<AirportDtoModel> GetAirportByIdAsync(int pId)
        {
            var entity = await _airportRepository.GetByIdAsync(pId);
            var model = _mapper.Map<AirportDtoModel>(entity);

            return model;
        }

        public async Task<AirportDtoModel> GetAirportByIdAsync(string pCode)
        {
            var entity = await _airportRepository.FindAsync(x => x.Code.Equals(pCode, StringComparison.OrdinalIgnoreCase));
            var model = _mapper.Map<AirportDtoModel>(entity.FirstOrDefault());

            return model;
        }

        public async Task<IList<AirportDtoModel>> GetAllAsync()
        {

            var entity = await _airportRepository.GetAllAsync();
            var model = _mapper.Map<IList<AirportDtoModel>>(entity);

            return model;
        }
    }
}
