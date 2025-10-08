using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs;
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
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Teacher> _baseRepository;
        private readonly ITeacherRepository _teacherRepository;
        public TeacherServices(IBaseRepository<Teacher> baseRepository, ITeacherRepository teacherRepository , IMapper mapper)
        {
            _baseRepository = baseRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<Teacher> AddNewAsync(TeacherDTO DTO)
        {
            Teacher teacher = _mapper.Map<Teacher>(DTO);
            return await _baseRepository.AddNewAsync(teacher);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Teacher?>> GetAllAsync()
        {
            var teachersList = await _baseRepository.GetAllAsync();
            return teachersList;
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            Teacher? teacher = await _baseRepository.GetByIdAsync(id);
            return teacher;
        }

        public async Task<Teacher?> GetByPersonIdAsync(int id)
        {
            var teachersList = await _baseRepository.GetAllAsync();
            Teacher? teacher = teachersList.FirstOrDefault(t => t.Id == id);
            return teacher;
        }

        public async Task<Teacher?> GetByTeacherCode(string code)
        {
            var teachersList = await _baseRepository.GetAllAsync();
            Teacher? teacher = teachersList.FirstOrDefault(t => t.TeacherCode == code);
            return teacher;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _teacherRepository.IsExist(id);
        }

        public async Task<bool> UpdateAsync(TeacherDTO entity)
        {
            Teacher teacher = _mapper.Map<Teacher>(entity);
            return await _baseRepository.UpdateAsync(teacher);
        }
        public async Task<bool> UpdateSalaryAsync(int Id, decimal salary)
        {
            return await _teacherRepository.UpdateTeacherSalary(Id, salary);
        }
    }
}
