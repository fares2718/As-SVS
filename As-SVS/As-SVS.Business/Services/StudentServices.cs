namespace As_SVS.Business.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _usertRepository;
        private readonly IGradeRepository _gradetRepository;
        private readonly IMapper _mapper;


        public StudentServices(IStudentRepository studentRepository, IUserRepository usertRepository, IMapper mapper, IGradeRepository gradetRepository)
        {
            _studentRepository = studentRepository;
            _usertRepository = usertRepository;
            _gradetRepository = gradetRepository;
            _mapper = mapper;
        }

        public async Task<int> AddNewAsync(StudentProfile studentDTO, string userId)
        {
            var student = _mapper.Map<Student>(studentDTO);
            student.applicationUser = await _usertRepository.GetUserByIdAsync(userId);
            int gradeNumber = studentDTO.Age switch
            {
                >= 5 and <= 6 => 1,    // الصف الأول
                >= 7 and < 8 => 2,     // الصف الثاني
                >= 8 and < 9 => 3,     // الصف الثالث
                >= 9 and < 10 => 4,    // الصف الرابع
                >= 10 and < 11 => 5,   // الصف الخامس
                >= 11 and < 12 => 6,   // الصف السادس
                >= 12 and < 13 => 7,   // الأول إعدادي
                >= 13 and < 14 => 8,   // الثاني إعدادي
                >= 14 and < 15 => 9,   // الثالث إعدادي
                >= 15 and < 16 => 10,  // الأول ثانوي
                >= 16 and < 17 => 11,  // الثاني ثانوي
                >= 17 and <= 18 => 12, // الثالث ثانوي
                _ => 0

            };
            student.Grade = await _gradetRepository.GetByNumberAsync(gradeNumber);
            student.StudentCode = $"{Guid.NewGuid().ToString()}";
            if (student.Grade.Number == 0)
                return -1;
            return await _studentRepository.AddNewAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            return await _studentRepository.DeleteStudentAsync(studentId);
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<StudentDTO> GetByIdAsync(int Id)
        {
            return await _studentRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<StudentDTO>> GetInGradeAsync(string gradeName)
        {
            var students = await GetAllAsync();
            return students.Where(s =>
                s.Grade == gradeName
            ).ToList();
        }

        public async Task<IEnumerable<StudentDTO>> SearchByNameAsync(string name)
        {
            return await _studentRepository.SearchByNameAsync(name);
        }
    }
}
