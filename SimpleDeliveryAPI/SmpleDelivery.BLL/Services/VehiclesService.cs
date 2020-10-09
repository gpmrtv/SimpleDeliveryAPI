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
    public class VehiclesService : IVehiclesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public VehiclesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async ValueTask<VehicleDTO> AddAsync(VehicleDTO vehicle)
        {
            var vehicles = (await _uow.GetRepository<VehicleEntity>().FindAsync(x => x.Number == vehicle.Number)).ToList();
            if (vehicles.Count != 0)
                throw new ValidationException("Vehicle exist");
            var addedVehicle = await _uow.GetRepository<VehicleEntity>().AddAsync(_mapper.Map<VehicleEntity>(vehicle));
            return _mapper.Map<VehicleDTO>(addedVehicle);
        }

        public async Task<IEnumerable<VehicleDTO>> FindAllAsync(Expression<Func<VehicleDTO, bool>> predicate)
        {
            var dalPredicate = _mapper.Map<Expression<Func<VehicleEntity, bool>>>(predicate);
            return _mapper.Map<IEnumerable<VehicleDTO>>(await _uow.GetRepository<VehicleEntity>().FindAsync(dalPredicate));
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<VehicleDTO>>(await _uow.GetRepository<VehicleEntity>().GetAllAsync());
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllAsync(Expression<Func<VehicleDTO, object>> expression)
        {
            var dalExpression = _mapper.Map<Expression<Func<VehicleEntity, object>>>(expression);
            return _mapper.Map<IEnumerable<VehicleDTO>>(await _uow.GetRepository<VehicleEntity>().GetAllAsync(dalExpression));
        }

        public async ValueTask<VehicleDTO> GetAsync(Guid id)
        {
            return _mapper.Map<VehicleDTO>(await _uow.GetRepository<VehicleEntity>().GetAsync(id));
        }

        public async Task RemoveAsync(Guid id)
        {
            await _uow.GetRepository<VehicleEntity>().RemoveAsync(id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Guid> ids)
        {
            await _uow.GetRepository<VehicleEntity>().RemoveRangeAsync(ids);
        }

        public async ValueTask<VehicleDTO> UpdateAsync(VehicleDTO vehicle)
        {
            var updatedVehicle = await _uow.GetRepository<VehicleEntity>().UpdateAsync(_mapper.Map<VehicleEntity>(vehicle));
            return _mapper.Map<VehicleDTO>(updatedVehicle);
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
