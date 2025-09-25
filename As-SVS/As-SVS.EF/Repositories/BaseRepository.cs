using As_SVS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly As_SVSContext _context;
        public BaseRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<T> AddNewAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T? entity = _context.Set<T>().Find(id);
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> entityList = await _context.Set<T>().ToListAsync();
            return entityList;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            T? entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
