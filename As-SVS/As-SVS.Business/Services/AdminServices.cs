using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
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
        private readonly IBaseRepository<Admin> _baseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AdminServices(IBaseRepository<Admin> baseRepository, IMapper mapper, IUserRepository userRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<int> AddNewAsync(AdminDTO adminDTO)
        {
            var admin = _mapper.Map<Admin>(adminDTO);
            admin.applicationUser = await _userRepository.GetUserByIdAsync(adminDTO.applicationUserId);
            return await _baseRepository.AddNewAsync(admin);
        }

        public Task<IEnumerable<Admin>> GetAllAsync()
        {
            return _baseRepository.GetAllAsync();
        }

        public async Task<Admin> GetByIdAsync(int Id)
        {
            return await _baseRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Admin>> SearchByNameAsync(string name)
        {
            return await _baseRepository.SearchByNameAsync(name);
        }
    }
}
