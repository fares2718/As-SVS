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
    public class TeacherRepository : IBaseRepository<Teacher>
    {
        private readonly As_SVSContext _context;

        public TeacherRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Teacher entity)
        {
            await _context.Teachers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(int Id)
        {
            var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Id == Id);
            if (teacher is null)
                return new Teacher();
            return teacher;
        }

        public async Task<IEnumerable<Teacher>> SearchByNameAsync(string name)
        {
            var teacherList = await _context.Teachers
                .Where(t => t.applicationUser.FullName.Contains(name))
                .AsNoTracking()
                .ToListAsync();
            if (!teacherList.Any())
                return Enumerable.Empty<Teacher>();
            return teacherList;
        }
    }
}
