using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class QuizeRepository : IQuizeRepository
    {
        private readonly As_SVSContext _context;
        private readonly IBaseRepository<Course> _baseRepository;

        public QuizeRepository(As_SVSContext context, IBaseRepository<Course> baseRepository)
        {
            _context = context;
            _baseRepository = baseRepository;
        }
        public async Task<int> AddNewAsync(Quize quize, int courseId, int moduleId)
        {
            var course = await _baseRepository.GetByIdAsync(courseId);
            var module = course.Modules.FirstOrDefault(m => m.Id == moduleId);
            if (course is null || module is null)
                return -1;
            module.Quizes.Add(quize);
            return quize.Id;
        }
    }
}
