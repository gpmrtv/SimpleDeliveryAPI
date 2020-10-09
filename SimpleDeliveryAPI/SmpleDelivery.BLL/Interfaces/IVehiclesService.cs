using SimpleDelivery.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelivery.BLL.Interfaces
{
    public interface IVehiclesService : IDisposable
    {
        ValueTask<VehicleDTO> GetAsync(Guid id);
        Task<IEnumerable<VehicleDTO>> GetAllAsync();
        Task<IEnumerable<VehicleDTO>> GetAllAsync(Expression<Func<VehicleDTO, object>> expression);
        Task<IEnumerable<VehicleDTO>> FindAllAsync(Expression<Func<VehicleDTO, bool>> predicate);
        ValueTask<VehicleDTO> AddAsync(VehicleDTO vehicle);
        ValueTask<VehicleDTO> UpdateAsync(VehicleDTO vehicle);
        Task RemoveAsync(Guid id);
        Task RemoveRangeAsync(IEnumerable<Guid> ids);
    }
}
