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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly As_SVSContext _context;
        public TeacherRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExist(int Id)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == Id);
            if (teacher == null)
                return false;
            return true;
        }

        public async Task<bool> UpdateTeacherSalary(int Id,decimal salary)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == Id);
            if (teacher == null)
                return false;
            teacher.Salary = salary;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
