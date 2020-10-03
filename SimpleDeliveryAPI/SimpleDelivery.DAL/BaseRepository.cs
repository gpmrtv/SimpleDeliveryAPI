using Microsoft.EntityFrameworkCore;
using SimpleDelivery.DAL.Interfaces;
using SimpleDelivery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelivery.DAL
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _entities;
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public virtual async ValueTask<TEntity> AddAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Created = DateTime.Now;

            var addedEntity = await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> expression)
        {
            return await _entities.AsNoTracking().Include(expression).Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> expression)
        {
            return await _entities.Include(expression).AsNoTracking().ToListAsync();
        }

        public virtual async ValueTask<TEntity> GetAsync(Guid id)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async ValueTask<TEntity> GetAsync(Guid id, Expression<Func<TEntity, object>> expression)
        {
            return await _entities.Include(expression).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            var dbEntity = await _entities.FindAsync(id);

            if (dbEntity is null)
            {
                throw new ArgumentNullException("Entry not found");
            }

            _entities.Remove(dbEntity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<Guid> ids)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach(var id in ids)
            {
                var dbEntity = await _entities.FindAsync(id);

                if (dbEntity is null)
                {
                    throw new ArgumentNullException("Entry not found");
                }

                entities.Add(dbEntity);
            }
            _entities.RemoveRange(entities);

            await _context.SaveChangesAsync();
        }

        public virtual async ValueTask<TEntity> UpdateAsync(TEntity entity)
        {
            var dbEntity = await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (dbEntity is null)
            {
                throw new ArgumentNullException("Entry not found");
            }

            var updatedEntity = _entities.Update(entity);           
            await _context.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
