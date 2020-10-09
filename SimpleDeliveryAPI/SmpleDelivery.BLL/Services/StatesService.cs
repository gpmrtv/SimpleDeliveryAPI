using AutoMapper;
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
    public class StatesService : IStatesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StatesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async ValueTask<StateDTO> AddAsync(StateDTO state)
        {
            var states = (await _uow.GetRepository<StateEntity>().FindAsync(x => x.Name == state.Name)).ToList();
            if (states.Count != 0)
                throw new ValidationException("State exist!");
            var addedState = await _uow.GetRepository<StateEntity>().AddAsync(_mapper.Map<StateEntity>(state));
            return _mapper.Map<StateDTO>(addedState);
        }

        public async Task<IEnumerable<StateDTO>> FindAllAsync(Expression<Func<StateDTO, bool>> predicate)
        {
            var dalPredicate = _mapper.Map<Expression<Func<StateEntity, bool>>>(predicate);
            return _mapper.Map<IEnumerable<StateDTO>>(await _uow.GetRepository<StateEntity>().FindAsync(dalPredicate));
        }

        public async Task<IEnumerable<StateDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StateDTO>>(await _uow.GetRepository<StateEntity>().GetAllAsync());
        }

        public async Task<IEnumerable<StateDTO>> GetAllAsync(Expression<Func<StateDTO, object>> expression)
        {
            var dalExpression = _mapper.Map<Expression<Func<StateEntity, object>>>(expression);
            return _mapper.Map<IEnumerable<StateDTO>>(await _uow.GetRepository<StateEntity>().GetAllAsync(dalExpression));
        }

        public async ValueTask<StateDTO> GetAsync(Guid id)
        {
            return _mapper.Map<StateDTO>(await _uow.GetRepository<StateEntity>().GetAsync(id));
        }

        public async Task RemoveAsync(Guid id)
        {
            await _uow.GetRepository<StateEntity>().RemoveAsync(id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Guid> ids)
        {
            await _uow.GetRepository<StateEntity>().RemoveRangeAsync(ids);
        }

        public async ValueTask<StateDTO> UpdateAsync(StateDTO state)
        {
            var updatedType = await _uow.GetRepository<StateEntity>().UpdateAsync(_mapper.Map<StateEntity>(state));
            return _mapper.Map<StateDTO>(updatedType);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _uow.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
