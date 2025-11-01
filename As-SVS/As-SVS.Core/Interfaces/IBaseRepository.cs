using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    //Interface that will be implemented by Admin, Teacher, Student and Course Repository
    public interface IBaseRepository <T> where T : class
    {
        Task<int> AddNewAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> SearchByNameAsync(string name);
    }
}
