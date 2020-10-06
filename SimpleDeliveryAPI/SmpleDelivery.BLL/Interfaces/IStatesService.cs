using SimpleDelivery.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelivery.BLL.Interfaces
{
    public interface IStatesService
    {
        ValueTask<StateDTO> GetAsync(Guid id);
        Task<IEnumerable<StateDTO>> GetAllAsync();
        Task<IEnumerable<StateDTO>> GetAllAsync(Expression<Func<StateDTO, object>> expression);
        Task<IEnumerable<StateDTO>> FindAllAsync(Expression<Func<StateDTO, bool>> predicate);
        ValueTask<StateDTO> AddAsync(StateDTO state);
        ValueTask<StateDTO> UpdateAsync(StateDTO state);
        Task RemoveAsync(Guid id);
        Task RemoveRangeAsync(IEnumerable<Guid> ids);
    }
}
