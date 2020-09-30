using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleDelivery.BLL.Dtos;
using SimpleDelivery.BLL.Interfaces;
using SimpleDelivery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelivery.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public CustomerService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public ValueTask<CustomerDTO> AddAsync(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDTO>> FindAllAsync(Expression<Func<CustomerDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<CustomerDTO> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public ValueTask<CustomerDTO> UpdateAsync(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}
