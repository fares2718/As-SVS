using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs;
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

        public TeacherServices(IBaseRepository<Teacher> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Task<TeacherDTO> AddNewAsync(TeacherDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeacherDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeacherDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TeacherDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
