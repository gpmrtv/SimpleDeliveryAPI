using SimpleDelivery.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelivery.BLL.Interfaces
{
    public interface IVehicleTypesService
    {
        ValueTask<VehicleTypeDTO> GetAsync(Guid id);
        Task<IEnumerable<VehicleTypeDTO>> GetAllAsync();
        Task<IEnumerable<VehicleTypeDTO>> GetAllAsync(Expression<Func<VehicleTypeDTO, object>> expression);
        Task<IEnumerable<VehicleTypeDTO>> FindAllAsync(Expression<Func<VehicleTypeDTO, bool>> predicate);
        ValueTask<VehicleTypeDTO> AddAsync(VehicleTypeDTO vehicleType);
        ValueTask<VehicleTypeDTO> UpdateAsync(VehicleTypeDTO vehicleType);
        Task RemoveAsync(Guid id);
        Task RemoveRangeAsync(IEnumerable<Guid> ids);
    }
}
