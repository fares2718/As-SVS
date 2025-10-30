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
    public class LessonsRepository : ILessonsRepository
    {
        private readonly As_SVSContext _context;

        public LessonsRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetModulesLessons(int moduleId)
        {
            var module = await _context.Modules.SingleOrDefaultAsync(m => m.Id == moduleId);
            return module.Lessons;
        }
    }
}
