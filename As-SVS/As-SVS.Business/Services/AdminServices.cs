using As_SVS.API.Helpers;
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

        #region Creat
        public async Task<int> AddNewAsync(Admin admin)
        {
            admin.Password = Cryptography.ComputeHash(admin.Password);
            await _baseRepository.AddNewAsync(admin);
            return admin.Id;
        }
        #endregion

        #region Read
        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
        #endregion

        #region Update

        public async Task<bool> UpdateAsync(Admin entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }

        public async Task AssignRoleAsync<T>(T entity)
        {
            await _adminRepository.AssignRoleAsync<T>(entity);
        }

        public async Task DeactivatePersonAsync(int Id)
        {
            await _adminRepository.DeactivatePersonAsync(Id);
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
