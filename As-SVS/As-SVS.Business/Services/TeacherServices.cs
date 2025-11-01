using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly IBaseRepository<Teacher> _baseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TeacherServices(IBaseRepository<Teacher> baseRepository, IMapper mapper, IUserRepository userRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<int> AddNewAsync(TeacherDTO teacherDTO)
        {
            var teacher = _mapper.Map<Teacher>(teacherDTO);
            teacher.applicationUser = await _userRepository.GetUserByIdAsync(teacherDTO.applicationUserId);
            return await _baseRepository.AddNewAsync(teacher);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<Teacher> GetByIdAsync(int Id)
        {
            return await _baseRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Teacher>> SearchByNameAsync(string name)
        {
            return await _baseRepository.SearchByNameAsync(name);
        }
    }
}
