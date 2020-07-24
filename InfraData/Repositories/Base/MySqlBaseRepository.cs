using Domain.Interfaces.Repositories.Base;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfraData.Repositories.Base
{
    public class MySqlBaseRepository<T> : IAsyncRepository<T>, IDisposable where T : class
    {
        private bool _disposedValue = false;

        protected MySqlDbContext _context;

        public MySqlBaseRepository(MySqlDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> CreateAsync(T entity)
        {
            var persisted = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return persisted.Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> where = null)
        {
            var query = _context.Set<T>();

            if (where != null)
            {
                var result = await query.Where(where).ToListAsync().ConfigureAwait(false);
                return result;
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ICollection<T>> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            List<T> exists = await _context.Set<T>().Where(predicate).ToListAsync();
            return exists.Any() ? true : false;
        }

        public async Task<Int64> CountAsync(Expression<Func<T, bool>> predicate)
        {
            List<T> exists = await _context.Set<T>().Where(predicate).ToListAsync();
            return exists.Any() ? exists.Count() : 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _context?.Dispose();
                _context = null;
                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MySqlBaseRepository()
        {
            Dispose(false);
        }
    }
}
