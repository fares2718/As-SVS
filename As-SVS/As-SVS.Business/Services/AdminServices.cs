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
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IBaseRepository<Admin> _baseRepository;
        public AdminServices(IAdminRepository adminRepository, IBaseRepository<Admin> baseRepository)
        {
            _adminRepository = adminRepository;
            _baseRepository = baseRepository;
        }
        public async Task AssignRoleAsync<T>(T entity)
        {
            await _adminRepository.AssignRoleAsync<T>(entity);
        }

        public async Task DeactivatePersonAsync(int Id)
        {
            await _adminRepository.DeactivatePersonAsync(Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id);
        }
    }
}
