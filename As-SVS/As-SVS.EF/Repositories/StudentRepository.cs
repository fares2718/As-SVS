using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using As_SVS.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly As_SVSContext _context;

        public StudentRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Student entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var query =
                from student in _context.Students
                join user in _context.Users
                    on student.applicationUserId equals user.Id
                join grade in _context.Grades
                    on student.GradeId equals grade.Id
                select new StudentDTO
                {
                    Id = student.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    motherName = student.MotherName,
                    studentCode = student.StudentCode,
                    Grade = grade.GradeLevel,
                    Average = student.Average,
                };
            return await query.ToListAsync();
        }

        public async Task<StudentDTO> GetByIdAsync(int Id)
        {
                        var query =
                from student in _context.Students
                join user in _context.Users
                    on student.applicationUserId equals user.Id
                join grade in _context.Grades
                    on student.GradeId equals grade.Id
                    where student.Id == student.Id
                select new StudentDTO
                {
                    Id = student.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    motherName = student.MotherName,
                    studentCode = student.StudentCode,
                    Grade = grade.GradeLevel,
                    Average = student.Average,
                    ImageUrl = user.ImageUrl
                };
            var Student = await query.FirstOrDefaultAsync();
            return Student ?? new StudentDTO();
        }

        public async Task<IEnumerable<StudentDTO>> SearchByNameAsync(string name)
        {
                                    var query =
                from student in _context.Students
                join user in _context.Users
                    on student.applicationUserId equals user.Id
                join grade in _context.Grades
                    on student.GradeId equals grade.Id
                    where (user.FullName.ToLower().Contains(name.ToLower()))
                select new StudentDTO
                {
                    Id = student.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    motherName = student.MotherName,
                    studentCode = student.StudentCode,
                    Grade = grade.GradeLevel,
                    Average = student.Average,
                    ImageUrl = user.ImageUrl
                };
            return await query.ToListAsync();
        }
    }
}
