using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly As_SVSContext _context;

        public GradeRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<Grade> GetByNumberAsync(int number)
        {
            if(!_context.Grades.Any(g => g.Number == number))
                return new Grade { Number = 0};
            var grade = await _context.Grades.SingleAsync(g => g.Number == number);
            return grade;
        }
    }
}
