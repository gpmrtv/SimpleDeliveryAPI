using SimpleDelivery.DAL.Models;
using System.Threading.Tasks;

namespace SimpleDelivery.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        Task<IRepository<TEntity>> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
