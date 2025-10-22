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
    public class StudentServices : IStudentServices
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Student> _baseRepository;
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IBaseRepository<Student> baseRepository, IMapper mapper, IStudentRepository studentRepository)
        {
            _baseRepository = baseRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        #region Creat
        public async Task<int> AddNewAsync(Student entity)
        {
            await _baseRepository.AddNewAsync(entity);
            return entity.Id;
        }
        #endregion

        #region Read
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Student>> GetAllInGrade(int GradeId)
        {
            return await _studentRepository.GetAllInGrade(GradeId);
        }

        public async Task<Student> GetByIdAsync(int Id)
        {
            return await _baseRepository.GetByIdAsync(Id);
        }

        public async Task<Student> GetByStudentCode(string code)
        {
            return await _studentRepository.GetByStudentCode(code);
        }

        #endregion

        #region Update
        public async Task<bool> UpdateAsync(Student entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id);
        }
        #endregion
    }
}
