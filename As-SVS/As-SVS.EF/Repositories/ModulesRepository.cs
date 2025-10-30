using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class ModulesRepository : IModulesRepository
    {
        private readonly As_SVSContext _context;
        private readonly IBaseRepository<Course> _baseRepository;

        public ModulesRepository(As_SVSContext context, IBaseRepository<Course> baseRepository)
        {
            _context = context;
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<As_SVS.Core.Models.Module>> GetAllModulesInCourseAsync(int courseId)
        {
            var course = await _baseRepository.GetByIdAsync(courseId);
            return course.Modules
                .ToList();
        }
    }
}
