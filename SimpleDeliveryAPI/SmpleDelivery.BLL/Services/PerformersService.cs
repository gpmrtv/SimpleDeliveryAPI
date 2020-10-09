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
    public class PerformersService : IPerformersService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PerformersService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async ValueTask<PerformerDTO> AddAsync(PerformerDTO performer)
        {
            var performers = (await _uow.GetRepository<PerformerEntity>().FindAsync(x => x.Email == performer.Email || x.Login == performer.Login)).ToList();
            if (performers.Count != 0)
                throw new ValidationException("Email/login exist");
            var addedPerformer = await _uow.GetRepository<PerformerEntity>().AddAsync(_mapper.Map<PerformerEntity>(performer));
            return _mapper.Map<PerformerDTO>(addedPerformer);
        }

        public async Task<IEnumerable<PerformerDTO>> FindAllAsync(Expression<Func<PerformerDTO, bool>> predicate)
        {
            var dalPredicate = _mapper.Map<Expression<Func<PerformerEntity, bool>>>(predicate);
            return _mapper.Map<IEnumerable<PerformerDTO>>(await _uow.GetRepository<PerformerEntity>().FindAsync(dalPredicate));
        }

        public async Task<IEnumerable<PerformerDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PerformerDTO>>(await _uow.GetRepository<PerformerEntity>().GetAllAsync());
        }

        public async Task<IEnumerable<PerformerDTO>> GetAllAsync(Expression<Func<PerformerDTO, object>> expression)
        {
            var dalExpression = _mapper.Map<Expression<Func<PerformerEntity, object>>>(expression);
            return _mapper.Map<IEnumerable<PerformerDTO>>(await _uow.GetRepository<PerformerEntity>().GetAllAsync(dalExpression));
        }

        public async ValueTask<PerformerDTO> GetAsync(Guid id)
        {
            return _mapper.Map<PerformerDTO>(await _uow.GetRepository<PerformerEntity>().GetAsync(id));
        }

        public async Task RemoveAsync(Guid id)
        {
            await _uow.GetRepository<PerformerEntity>().RemoveAsync(id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Guid> ids)
        {
            await _uow.GetRepository<PerformerEntity>().RemoveRangeAsync(ids);
        }

        public async ValueTask<PerformerDTO> UpdateAsync(PerformerDTO performer)
        {
            var updatedPerformer = await _uow.GetRepository<PerformerEntity>().UpdateAsync(_mapper.Map<PerformerEntity>(performer));
            return _mapper.Map<PerformerDTO>(updatedPerformer);
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
