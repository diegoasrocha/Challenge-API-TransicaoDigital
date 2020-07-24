using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IAsyncRepository<T>
    {
        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> where = null);

        Task<ICollection<T>> SearchAsync(Expression<Func<T, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        Task<Int64> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
