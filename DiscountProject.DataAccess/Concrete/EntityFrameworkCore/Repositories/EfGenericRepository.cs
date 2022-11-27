using DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using DiscountProject.DataAccess.Interfaces;
using DiscountProject.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, ITable, new()
    {
        private readonly DatabaseContext _context;

        public EfGenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllFilterAndOrderByAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector)
        {
            return await _context.Set<T>().Where(filter).OrderBy(keySelector).ToListAsync();
        }

        public async Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAllOrderByAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return await _context.Set<T>().OrderBy(keySelector).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<int> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}
