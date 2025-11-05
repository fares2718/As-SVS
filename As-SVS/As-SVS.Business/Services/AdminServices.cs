using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using As_SVS.DTOs.VideoDTO;
using AutoMapper;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AdminServices(IAdminRepository adminRepository, IMapper mapper, IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<int> AddNewAsync(AdminDTO adminDTO,string userId)
        {
            var admin = _mapper.Map<Admin>(adminDTO);
            admin.applicationUser = await _userRepository.GetUserByIdAsync(userId);
            return await _adminRepository.AddNewAsync(admin);
        }

        public Task<IEnumerable<AdminDTO>> GetAllAsync()
        {
            return _adminRepository.GetAllAsync();
        }

        public async Task<AdminDTO> GetByIdAsync(int Id)
        {
            return await _adminRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<AdminDTO>> SearchByNameAsync(string name)
        {
            return await _adminRepository.SearchByNameAsync(name);
        }

        public async Task<bool> UpdateAdminSalaryAsync(int adminId, decimal newSalary)
        {
            return await _adminRepository.UpdateAdminSalaryAsync(adminId, newSalary);
        }
    }
}
