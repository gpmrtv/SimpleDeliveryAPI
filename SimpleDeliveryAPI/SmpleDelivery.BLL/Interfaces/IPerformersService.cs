using SimpleDelivery.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelivery.BLL.Interfaces
{
    public interface IPerformersService : IDisposable
    {
        ValueTask<PerformerDTO> GetAsync(Guid id);
        Task<IEnumerable<PerformerDTO>> GetAllAsync();
        Task<IEnumerable<PerformerDTO>> GetAllAsync(Expression<Func<PerformerDTO, object>> expression);
        Task<IEnumerable<PerformerDTO>> FindAllAsync(Expression<Func<PerformerDTO, bool>> predicate);
        ValueTask<PerformerDTO> AddAsync(PerformerDTO performer);
        ValueTask<PerformerDTO> UpdateAsync(PerformerDTO performer);
        Task RemoveAsync(Guid id);
        Task RemoveRangeAsync(IEnumerable<Guid> ids);
    }
}
