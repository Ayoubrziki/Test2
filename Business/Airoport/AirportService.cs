using AutoMapper;
using Core.Serilog;
using Domain.Dto;
using Domain.Entities;
using Persistence;

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
            try
            {
                Logger.Info("Start GetAirportByIdAsync ....");

                var entity = await _airportRepository.GetByIdAsync(pId);
                var model = _mapper.Map<AirportDtoModel>(entity);

                Logger.Info("Airport id in database : {0}.", model.Id);
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AirportDtoModel> GetAirportByCodeAsync(string pCode)
        {
            try
            {
                Logger.Info("Start GetAirportByCodeAsync ....");

                var entity = await _airportRepository.FindAsync(x => x.Code.Equals(pCode, StringComparison.OrdinalIgnoreCase));
                var model = _mapper.Map<AirportDtoModel>(entity.FirstOrDefault());

                Logger.Info("Airport code in database : {0}.", model.Code);
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<AirportDtoModel>> GetAllAsync()
        {
            try
            {
                Logger.Info("Start GetAllAsync ....");

                var entities = await _airportRepository.GetAllAsync();
                var model = _mapper.Map<IList<AirportDtoModel>>(entities);

                Logger.Info("Airport count in database : {0}.", entities.Count());
                return model;
            }
            catch
            {
                throw;
            }
        }
    }
}
