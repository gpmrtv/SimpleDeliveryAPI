using SimpleDelivery.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelivery.BLL.Interfaces
{
    public interface ICustomersService
    {
        ValueTask<CustomerDTO> GetAsync(Guid id);
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<IEnumerable<CustomerDTO>> GetAllAsync(Expression<Func<CustomerDTO, object>> expression);
        Task<IEnumerable<CustomerDTO>> FindAllAsync(Expression<Func<CustomerDTO, bool>> predicate);
        ValueTask<CustomerDTO> AddAsync(CustomerDTO customer);
        ValueTask<CustomerDTO> UpdateAsync(CustomerDTO customer);
        Task RemoveAsync(Guid id);
        Task RemoveRangeAsync(IEnumerable<Guid> ids);
    }
}
