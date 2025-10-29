using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        Task<IEnumerable<T>>? GetAllAsync();
        Task<T>? GetByIdAsync(int id);
        Task<bool> AddAsync (T entity);
        Task<bool> UpdateAsync (T entity);
    }
}
