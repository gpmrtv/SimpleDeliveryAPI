using SimpleDelivery.DAL.Models;
using System;
using System.Threading.Tasks;

namespace SimpleDelivery.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
