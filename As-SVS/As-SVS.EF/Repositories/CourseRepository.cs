namespace AsSVS.EF.Repositories
{
    public class CourseRepository :  ICourseRepository
    {
        private readonly As_SVSContext _context;

        
        public CourseRepository(As_SVSContext context)
        {
            _context = context;
        }

        #region User
        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var query =
                await _context.Courses
                    .Select(
                    course => new CourseDTO
                    {
                        Id = course.Id,
                        Name = course.Name,
                        CourseCode = course.CourseCode??string.Empty,
                        Description = course.Description??string.Empty,
                        Room = course.Room.Title,
                        Modules = course.Modules
                            .Select(
                                module => new ModuleDTO
                                {
                                    Id = module.Id,
                                    Name = module.Name,
                                    Grade = course.Grade.GradeLevel,
                                    Number = module.Number,
                                    Teacher = course.Teacher.applicationUser.FullName,
                                    Lessons = module.Lessons
                                        .Select(
                                        lesson => new LessonDTO
                                        {
                                            Id = lesson.Id,
                                            Name = lesson.Name,
                                            VideoUrl = lesson.VideoUrl,
                                            CourseOrder = lesson.CourseOrder,
                                            LessonDetails = lesson.LessonDetails,
                                            Number = lesson.Number
                                        }
                                        ).ToList(),
                                }
                            ).ToList()
                    }
                    )
                    .AsNoTracking()
                    .ToListAsync();
            return query;
        }
        public async Task<CourseDTO> GetByIdAsync(int Id)
        {
             var query =
                await _context.Courses.Where(c => c.Id == Id)
                    .Select(
                    course => new CourseDTO
                    {
                        Id = course.Id,
                        Name = course.Name,
                        CourseCode = course.CourseCode ?? string.Empty,
                        Description = course.Description ?? string.Empty,
                        Room = course.Room.Title,
                        Modules = course.Modules
                            .Select(
                                module => new ModuleDTO
                                {
                                    Id = module.Id,
                                    Name = module.Name,
                                    Grade = course.Grade.GradeLevel,
                                    Number = module.Number,
                                    Teacher = course.Teacher.applicationUser.FullName,
                                    Lessons = module.Lessons
                                        .Select(
                                        lesson => new LessonDTO
                                        {
                                            Id = lesson.Id,
                                            Name = lesson.Name,
                                            VideoUrl = lesson.VideoUrl,
                                            CourseOrder = lesson.CourseOrder,
                                            LessonDetails = lesson.LessonDetails,
                                            Number = lesson.Number
                                        }
                                        ).ToList(),
                                }
                            ).ToList()
                    }
                    ).SingleOrDefaultAsync();
            return query ?? new CourseDTO();
        }
        public async Task<IEnumerable<CourseDTO>> SearchByNameAsync(string name)
        {
            var query =
                await _context.Courses.Where(c => c.Name.ToLower().Contains(name.ToLower()))
                    .Select(
                    course => new CourseDTO
                    {
                        Id = course.Id,
                        Name = course.Name,
                        CourseCode = course.CourseCode ?? string.Empty,
                        Description = course.Description?? string.Empty,
                        Room = course.Room.Title,
                        Modules = course.Modules
                            .Select(
                                module => new ModuleDTO
                                {
                                    Id = module.Id,
                                    Name = module.Name,
                                    Grade = course.Grade.GradeLevel,
                                    Number = module.Number,
                                    Teacher = course.Teacher.applicationUser.FullName,
                                    Lessons = module.Lessons
                                        .Select(
                                        lesson => new LessonDTO
                                        {
                                            Id = lesson.Id,
                                            Name = lesson.Name,
                                            VideoUrl = lesson.VideoUrl,
                                            CourseOrder = lesson.CourseOrder,
                                            LessonDetails = lesson.LessonDetails,
                                            Number = lesson.Number
                                        }
                                        ).ToList(),
                                }
                            ).ToList()
                    }
                    ).ToListAsync();
            return query;
        }

        #endregion

        #region Student
        public async Task<IEnumerable<EnrollmentDTO>> GetEnrolledCoursesAsync(int studentId)
        {
            var query =
                from course in _context.Courses
                join enrolment in _context.Enrolments
                    on course.Id equals enrolment.CourseId
                join student in _context.Students
                    on enrolment.StudentId equals student.Id
                select new EnrollmentDTO
                {
                    Student = student.applicationUser.FullName,
                    Course = course.Name,
                    EnrollmentDate = enrolment.EnrolmentDate,
                };
            return await query
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task EnrollInCourseAsync(int studentId, int courseId)
        {
            if(!_context.Students.Any(s => s.Id == studentId)
                ||!_context.Courses.Any(c => c.Id == courseId))
            {
                return;
            }
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Id == studentId);
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
            if (student is null || course is null)
                return;
            if (student.GradeId == course.GradeId)
            {
                await _context.Enrolments.AddAsync(
                    new Enrolment
                    {
                        Student = student,
                        Course = course,
                        CourseId = courseId,
                        StudentId = studentId,
                        EnrolmentDate = DateTime.UtcNow
                    });
                await _context.SaveChangesAsync();
            }
        }
        public bool IsStudentEnrolled(int studentId, int courseId)
        {
           var Enrollment = _context.Enrolments.FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);
           return Enrollment != null;
        }

        #endregion

        #region Teacher

        public async Task<int> AddNewAsync(Course entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        #endregion(

    }
}
