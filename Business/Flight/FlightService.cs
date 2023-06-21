using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Persistence;

namespace Business.Flight
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Flight> _flightRepository;

        public FlightService(IMapper mapper,
            IRepository<Domain.Entities.Flight> flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task DeleteAsync(FlightDtoModel model)
        {
            var entity = _mapper.Map<Domain.Entities.Flight>(model);
            await _flightRepository.DeleteAsync(entity);
        }

        public async Task<IList<FlightDtoModel>> GetAllAsync()
        {
            var entities = await _flightRepository.GetAllAsync();
            var model = _mapper.Map<IList<FlightDtoModel>>(entities);

            return model;
        }

        public async Task<FlightDtoModel> GetByIdAsync(int pId)
        {
            var entity = await _flightRepository.GetByIdAsync(pId);
            var model = _mapper.Map<FlightDtoModel>(entity);

            return model;
        }

        public async Task InsertAsync(FlightDtoModel model)
        {
            var entity=_mapper.Map<Domain.Entities.Flight>(model);
            await _flightRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(FlightDtoModel model)
        {
            var entity = _mapper.Map<Domain.Entities.Flight>(model);
            await _flightRepository.UpdateAsync(entity);
        }
    }
}
