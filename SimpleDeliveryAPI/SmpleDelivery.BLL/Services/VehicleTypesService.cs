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
    public class VehicleTypesService : IVehicleTypesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public VehicleTypesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async ValueTask<VehicleTypeDTO> AddAsync(VehicleTypeDTO vehicleType)
        {
            var vehicleTypes = (await _uow.GetRepository<VehicleTypeEntity>().FindAsync(x => x.Name == vehicleType.Name)).ToList();
            if (vehicleTypes.Count != 0)
                throw new ValidationException("Vehicle type exist!");
            var addedType = await _uow.GetRepository<VehicleTypeEntity>().AddAsync(_mapper.Map<VehicleTypeEntity>(vehicleType));
            return _mapper.Map<VehicleTypeDTO>(addedType);
        }

        public async Task<IEnumerable<VehicleTypeDTO>> FindAllAsync(Expression<Func<VehicleTypeDTO, bool>> predicate)
        {
            var dalPredicate = _mapper.Map<Expression<Func<VehicleTypeEntity, bool>>>(predicate);
            return _mapper.Map<IEnumerable<VehicleTypeDTO>>(await _uow.GetRepository<VehicleTypeEntity>().FindAsync(dalPredicate));
        }

        public async Task<IEnumerable<VehicleTypeDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<VehicleTypeDTO>>(await _uow.GetRepository<VehicleTypeEntity>().GetAllAsync());
        }

        public async Task<IEnumerable<VehicleTypeDTO>> GetAllAsync(Expression<Func<VehicleTypeDTO, object>> expression)
        {
            var dalExpression = _mapper.Map<Expression<Func<VehicleTypeEntity, object>>>(expression);
            return _mapper.Map<IEnumerable<VehicleTypeDTO>>(await _uow.GetRepository<VehicleTypeEntity>().GetAllAsync(dalExpression));
        }

        public async ValueTask<VehicleTypeDTO> GetAsync(Guid id)
        {
            return _mapper.Map<VehicleTypeDTO>(await _uow.GetRepository<VehicleTypeEntity>().GetAsync(id));
        }

        public async Task RemoveAsync(Guid id)
        {
            await _uow.GetRepository<VehicleTypeEntity>().RemoveAsync(id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Guid> ids)
        {
            await _uow.GetRepository<VehicleTypeEntity>().RemoveRangeAsync(ids);
        }

        public async ValueTask<VehicleTypeDTO> UpdateAsync(VehicleTypeDTO vehicleType)
        {
            var updatedType = await _uow.GetRepository<VehicleTypeEntity>().UpdateAsync(_mapper.Map<VehicleTypeEntity>(vehicleType));
            return _mapper.Map<VehicleTypeDTO>(updatedType);
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
