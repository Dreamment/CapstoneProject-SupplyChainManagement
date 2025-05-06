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

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAllAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAllByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAllByConditionWithDetailsAsync(Expression<Func<T, bool>> expression, bool trackChanges, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAllWithDetailsAsync(bool trackChanges, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByConditionWithDetailsAsync(Expression<Func<T, bool>> expression, bool trackChanges, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
