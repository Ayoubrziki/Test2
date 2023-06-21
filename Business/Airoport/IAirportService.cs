using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Airoport
{
    public interface IAirportService
    {
        Task<AirportDtoModel> GetAirportByIdAsync(int pId);
        Task<AirportDtoModel> GetAirportByCodeAsync(string pCode);
        Task<IList<AirportDtoModel>> GetAllAsync();
    }
}
