using AutoMapper;
using Core.Serilog;
using Domain.Dto;
using Domain.Entities;
using Persistence;
using System.Security.Cryptography;

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

        public async Task DeleteAsync(int pId)
        {
            try
            {
                Logger.Info("Start DeleteAsync ....");

                var entity = await _flightRepository.GetByIdAsync(pId);
                await _flightRepository.DeleteAsync(entity);

                Logger.Info("Flight {0} deleted successfuly.", pId);
            }
            catch
            {
                throw;
            }

        }

        public async Task<IList<FlightDtoModel>> GetAllAsync()
        {
            try
            {
                Logger.Info("Start GetAllAsync ....");

                var entities = await _flightRepository.GetAllAsync();
                var model = _mapper.Map<IList<FlightDtoModel>>(entities);

                Logger.Info("Flight count in database : {0}.", entities.Count());
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<FlightDtoModel> GetByIdAsync(int pId)
        {
            try
            {
                Logger.Info("Start GetByIdAsync ....");

                var entity = await _flightRepository.GetByIdAsync(pId);
                var model = _mapper.Map<FlightDtoModel>(entity);


                Logger.Info("Flight id in database : {0}.", model.Id);
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task InsertAsync(FlightDtoModel model)
        {
            try
            {
                Logger.Info("Start InsertAsync ....");

                var entity = _mapper.Map<Domain.Entities.Flight>(model);
                await _flightRepository.AddAsync(entity);

                Logger.Info("Flight inserted successfuly.");
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAsync(FlightDtoModel model)
        {
            try
            {
                Logger.Info("Start UpdateAsync ....");

                var entity = _mapper.Map<Domain.Entities.Flight>(model);
                await _flightRepository.UpdateAsync(entity);

                Logger.Info("Flight {0} updated successfuly.", entity.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
