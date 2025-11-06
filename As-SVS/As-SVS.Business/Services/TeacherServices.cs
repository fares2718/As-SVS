namespace As_SVS.Business.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TeacherServices(ITeacherRepository teacherRepository, IMapper mapper, IUserRepository userRepository)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<int> AddNewAsync(TeacherDTO teacherDTO,string userId)
        {
            var teacher = _mapper.Map<Teacher>(teacherDTO);
            teacher.applicationUser = await _userRepository.GetUserByIdAsync(userId);
            return await _teacherRepository.AddNewAsync(teacher);
        }

        public async Task<IEnumerable<TeacherDTO>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<TeacherDTO> GetByIdAsync(int Id)
        {
            return await _teacherRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<TeacherDTO>> SearchByNameAsync(string name)
        {
            return await _teacherRepository.SearchByNameAsync(name);
        }

        public async Task<bool> UpdateTeacherSalaryAsync(int adminId, decimal newSalary)
        {
            return await _teacherRepository.UpdateTeacherSalaryAsync(adminId, newSalary);
        }
    }
}
