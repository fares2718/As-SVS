using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.EF.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly As_SVSContext _context;
        public StudentRepository(As_SVSContext context)
        {
                _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllInGrade(int GradeId)
        {
            return await _context.Students
                .Where(s => s.GradeId == GradeId)
                .OrderBy(s => s.Person.FullName())
                .AsNoTracking()
                .ToListAsync();
                
        }

        public async Task<Student> GetByStudentCode(string code)
        {
            Student? student = await _context.Students.FirstOrDefaultAsync(x => x.StudentCode == code);
            if (student != null)
                return student;
            return default!;
        }
    }
}
