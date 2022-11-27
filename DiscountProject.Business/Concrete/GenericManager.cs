using DiscountProject.Business.Interfaces;
using DiscountProject.DataAccess.Interfaces;
using DiscountProject.Entities.Interfaces;
using System.Linq.Expressions;

namespace DiscountProject.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, ITable, new()
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<int> AddAsync(T entity)
        {
            return await _genericDal.AddAsync(entity);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _genericDal.FindByIdAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<List<T>> GetAllFilterAndOrderByAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector)
        {
            return await _genericDal.GetAllFilterAndOrderByAsync(filter, keySelector);
        }

        public async Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _genericDal.GetAllFilterAsync(filter);
        }

        public async Task<List<T>> GetAllOrderByAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return await _genericDal.GetAllOrderByAsync(keySelector);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _genericDal.GetAsync(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
        {
            return await _genericDal.GetCountAsync(filter);
        }

        public async Task<int> RemoveAsync(T entity)
        {
            return await _genericDal.RemoveAsync(entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await _genericDal.UpdateAsync(entity);
        }
    }
}
