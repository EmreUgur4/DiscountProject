using DiscountProject.Entities.Interfaces;
using System.Linq.Expressions;

namespace DiscountProject.Business.Interfaces
{
    public interface IGenericService<T> where T : class, ITable, new()
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllFilterAndOrderByAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector);
        Task<List<T>> GetAllOrderByAsync<TKey>(Expression<Func<T, TKey>> keySelector);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter);
        Task<T> FindByIdAsync(int id);
        Task<int> UpdateAsync(T entity);
        Task<int> AddAsync(T entity);
        Task<int> RemoveAsync(T entity);
    }
}
