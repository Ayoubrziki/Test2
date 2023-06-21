using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Flight
{
    public interface IFlightService
    {
        Task<IList<FlightDtoModel>> GetAllAsync();
        Task<FlightDtoModel> GetByIdAsync(int pId);
        Task InsertAsync(FlightDtoModel model);
        Task UpdateAsync(FlightDtoModel model);
        Task DeleteAsync(FlightDtoModel model);
    }
}
