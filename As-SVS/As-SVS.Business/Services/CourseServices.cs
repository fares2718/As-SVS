using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly IBaseRepository<Course> _baseRepository;

        public CourseServices(IBaseRepository<Course> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<Course> GetByIdAsync(int Id)
        {
            return await _baseRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Course>> SearchByNameAsync(string name)
        {
            return await _baseRepository.SearchByNameAsync(name);
        }
    }
}
