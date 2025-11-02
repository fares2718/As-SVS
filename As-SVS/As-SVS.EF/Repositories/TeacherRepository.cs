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
    public class TeacherRepository : ITeacherRepository
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

        public async Task<IEnumerable<TeacherDTO>> GetAllAsync()
        {
            var query =
                from teacher in _context.Teachers
                join user in _context.Users
                    on teacher.applicationUserId equals user.Id
                join grade in _context.Grades
                    on teacher.Id equals grade.Id
                join course in _context.Courses
                    on teacher.Id equals course.TeacherId
                select new TeacherDTO
                {
                    Id = teacher.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    TeacherCode = teacher.TeacherCode,
                    Specialization = teacher.Specialization,
                    Qualifications = teacher.Qualifications,
                    Course = course.Name,
                    Grade = grade.GradeLevel,
                    Salary = teacher.Salary
                };
            return await query.ToListAsync();
        }

        public async Task<TeacherDTO> GetByIdAsync(int Id)
        {
                        var query =
                from teacher in _context.Teachers
                join user in _context.Users
                    on teacher.applicationUserId equals user.Id
                join grade in _context.Grades
                    on teacher.Id equals grade.Id
                join course in _context.Courses
                    on teacher.Id equals course.TeacherId
                where teacher.Id == Id
                select new TeacherDTO
                {
                    Id = teacher.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    TeacherCode = teacher.TeacherCode,
                    Specialization = teacher.Specialization,
                    Qualifications = teacher.Qualifications,
                    Course = course.Name,
                    Grade = grade.GradeLevel,
                    Salary = teacher.Salary,
                    ImageUrl = user.ImageUrl
                };
            var Teacher = await query.FirstOrDefaultAsync();
            return Teacher ?? new TeacherDTO();
        }

        public async Task<IEnumerable<TeacherDTO>> SearchByNameAsync(string name)
        {
                        var query =
                from teacher in _context.Teachers
                join user in _context.Users
                    on teacher.applicationUserId equals user.Id
                join grade in _context.Grades
                    on teacher.Id equals grade.Id
                join course in _context.Courses
                    on teacher.Id equals course.TeacherId
                    where (user.FullName.ToLower().Contains(name.ToLower()))
                select new TeacherDTO
                {
                    Id = teacher.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    TeacherCode = teacher.TeacherCode,
                    Specialization = teacher.Specialization,
                    Qualifications = teacher.Qualifications,
                    Course = course.Name,
                    Grade = grade.GradeLevel,
                    Salary = teacher.Salary
                };
            return await query.ToListAsync();
        }
    }
}
