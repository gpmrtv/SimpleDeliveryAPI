using Microsoft.EntityFrameworkCore;
using SimpleDelivery.DAL.EF;
using SimpleDelivery.DAL.Interfaces;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelivery.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        
        public UnitOfWork(DeliveryContext context)
        {
            _context = context;
        }
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return new BaseRepository<TEntity>(_context);
        }
    }
}
