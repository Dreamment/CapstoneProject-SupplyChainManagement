using System.Linq.Expressions;

namespace Repositories.Contratcs
{
    public interface IRepositoryBase<T> where T : class
    {
        Task CreateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IEnumerable<T>> FindAllAsync(bool trackChanges);

        Task<IEnumerable<T>> FindAllByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);

        Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);

        Task<IEnumerable<T>> FindAllWithDetailsAsync(bool trackChanges, params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> FindAllByConditionWithDetailsAsync(Expression<Func<T, bool>> expression, bool trackChanges,
            params Expression<Func<T, object>>[] includes);

        Task<T> FindByConditionWithDetailsAsync(Expression<Func<T, bool>> expression, bool trackChanges,
            params Expression<Func<T, object>>[] includes);

        Task UpdateAsync(T entity);
    }
}
