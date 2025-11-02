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

        public ModulesRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(As_SVS.Core.Models.Module module, int courseId)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
            if (course is null)
                return -1;
            course.Modules.Add(module);
            await _context.SaveChangesAsync();
            return module.Id;
        }

    }
}
