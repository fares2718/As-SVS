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
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _usertRepository;
        private readonly IMapper _mapper;


        public StudentServices(IStudentRepository studentRepository, IUserRepository usertRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _usertRepository = usertRepository;
            _mapper = mapper;
        }

        public async Task<int> AddNewAsync(StudentDTO studentDTO, string userId)
        {
            var student = _mapper.Map<Student>(studentDTO);
            student.applicationUser = await _usertRepository.GetUserByIdAsync(userId);
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
