using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
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
        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task AssignRoleAsync<T>(T entity)
        {
            await _adminRepository.AssignRoleAsync<T>(entity);
        }

        public async Task DeactivatePersonAsync(int Id)
        {
            await _adminRepository.DeactivatePersonAsync(Id);
        }
    }
}
