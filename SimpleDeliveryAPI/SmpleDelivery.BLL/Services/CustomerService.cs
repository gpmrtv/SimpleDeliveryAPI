using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleDelivery.BLL.Dtos;
using SimpleDelivery.BLL.Infrastructure.Exceptions;
using SimpleDelivery.BLL.Interfaces;
using SimpleDelivery.DAL.Interfaces;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async ValueTask<CustomerDTO> AddAsync(CustomerDTO customer)
        {
            var customers = (await _uow.GetRepository<CustomerEntity>().FindAsync(x => x.Email == customer.Email || x.Login == customer.Login)).ToList();
            if (customers.Count != 0)
                throw new ValidationException("Email/login exist");
            var addedCust = await _uow.GetRepository<CustomerEntity>().AddAsync(_mapper.Map<CustomerEntity>(customer));
            return _mapper.Map<CustomerDTO>(addedCust);
        }

        public async Task<IEnumerable<CustomerDTO>> FindAllAsync(Expression<Func<CustomerDTO, bool>> predicate)
        {
            var dalPredicate = _mapper.Map<Expression<Func<CustomerEntity, bool>>>(predicate);
            return _mapper.Map<IEnumerable<CustomerDTO>>(await _uow.GetRepository<CustomerEntity>().FindAsync(dalPredicate));
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(await _uow.GetRepository<CustomerEntity>().GetAllAsync());
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync(Expression<Func<CustomerDTO, object>> expression)
        {
            var dalExpression = _mapper.Map<Expression<Func<CustomerEntity, object>>>(expression);
            return _mapper.Map<IEnumerable<CustomerDTO>>(await _uow.GetRepository<CustomerEntity>().GetAllAsync(dalExpression));
        }

        public async ValueTask<CustomerDTO> GetAsync(Guid id)
        {
            return _mapper.Map<CustomerDTO>(await _uow.GetRepository<CustomerEntity>().GetAsync(id));
        }

        public async Task RemoveAsync(Guid id)
        {
            await _uow.GetRepository<CustomerEntity>().RemoveAsync(id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Guid> ids)
        {
            await _uow.GetRepository<CustomerEntity>().RemoveRangeAsync(ids);
        }

        public async ValueTask<CustomerDTO> UpdateAsync(CustomerDTO customer)
        {
            var updatedCust = await _uow.GetRepository<CustomerEntity>().UpdateAsync(_mapper.Map<CustomerEntity>(customer));
            return _mapper.Map<CustomerDTO>(updatedCust);
        }
    }
}
