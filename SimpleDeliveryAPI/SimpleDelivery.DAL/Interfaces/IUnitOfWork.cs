using SimpleDelivery.DAL.Models;
using System.Threading.Tasks;

namespace SimpleDelivery.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
