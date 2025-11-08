namespace AsSVS.EF.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly As_SVSContext _context;

        public StudentRepository(As_SVSContext context)
        {
            _context = context;
        }

        #region Creat
        public async Task<int> AddNewAsync(Student entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            if (!await _context.Students.AnyAsync(s => s.Id == studentId))
                return false;
            var student = await _context.Students.SingleAsync(s => s.Id == studentId);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return await _context.Students.AnyAsync(s => s.Id == studentId);
        }
        #endregion

        #region Read
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
                    Grade = grade.Number.ToString(),
                    Average = student.Average,
                };
            return await query
                .AsNoTracking()
                .ToListAsync();
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
                    ImageUrl = user.ImageUrl??string.Empty
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
                    ImageUrl = user.ImageUrl??string.Empty
                };
            return await query
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion
    }
}
