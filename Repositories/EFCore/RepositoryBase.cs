using Microsoft.EntityFrameworkCore;
using Repositories.Contratcs;
using System.Linq.Expressions;

namespace Repositories.EFCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public async Task DeleteAsync(T entity)
            => await Task.Run(() => _context.Set<T>().Remove(entity));

        public async Task<IEnumerable<T>> FindAllAsync(bool trackChanges)
            => !trackChanges ?
            await _context.Set<T>().AsNoTracking().ToListAsync() :
            await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> FindAllByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
            => trackChanges ?
            await _context.Set<T>().Where(expression).ToListAsync() :
            await _context.Set<T>().AsNoTracking().Where(expression).ToListAsync();

        public async Task<IEnumerable<T>> FindAllByConditionWithDetailsAsync(Expression<Func<T, bool>> expression, bool trackChanges, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return !trackChanges ?
                await query.AsNoTracking().Where(expression).ToListAsync() :
                await query.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllWithDetailsAsync(bool trackChanges, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return !trackChanges ?
                await query.AsNoTracking().ToListAsync() :
                await query.ToListAsync();
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
#pragma warning disable CS8603 // Possible null reference return.
            => trackChanges ?
                await _context.Set<T>().Where(expression).FirstOrDefaultAsync() :
                await _context.Set<T>().AsNoTracking().Where(expression).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.

        public async Task<T> FindByConditionWithDetailsAsync(Expression<Func<T, bool>> expression, bool trackChanges, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return trackChanges ?
                await query.Where(expression).FirstOrDefaultAsync() :
                await query.AsNoTracking().Where(expression).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
            => await Task.Run(() => _context.Set<T>().Update(entity));
    }
}
