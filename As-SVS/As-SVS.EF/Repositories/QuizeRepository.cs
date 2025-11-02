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
    public class QuizeRepository : IQuizeRepository
    {
        private readonly As_SVSContext _context;

        public QuizeRepository(As_SVSContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewAsync(Quize quize, int courseId, int moduleId)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
            var module = course.Modules.SingleOrDefault(m => m.Id == moduleId);
            if (course is null || module is null)
                return -1;
            module.Quizes.Add(quize);
            await _context.SaveChangesAsync();
            return quize.Id;
        }
    }
}
