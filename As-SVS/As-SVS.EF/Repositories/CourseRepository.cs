using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class CourseRepository : IBaseRepository<Course>
    {
        private readonly As_SVSContext _context;

        public CourseRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int Id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == Id);
            return course ?? new Course();
        }
    }
}
