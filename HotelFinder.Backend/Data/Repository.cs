

using HotelFinder.Backend.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HotelFinderContext context;
        private DbSet<T> entities;

        public Repository(HotelFinderContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
        public async Task<T> Get(long id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<int> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await entities.AnyAsync(entity => entity.Id == id);
        }

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = entities.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }

            if (includeProperties != null)
            {
                query =  ApplyIncludesOnQuery(query, includeProperties);
            }

            return await query.ToListAsync();
        }

        public IQueryable<T> ApplyIncludesOnQuery(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties) 
        {
            return (includeProperties.Aggregate(query, (current, include) => current.Include(include)));
        }

    }
}