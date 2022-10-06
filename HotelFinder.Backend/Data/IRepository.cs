using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelFinder.Backend
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        Task<int> Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exists(int id);
        Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}