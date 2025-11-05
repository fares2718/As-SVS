using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using As_SVS.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly As_SVSContext _context;

        public AdminRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Admin entity)
        {
            await _context.Admins.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<AdminDTO>> GetAllAsync()
        {
            var query =
                from admin in _context.Admins
                join user in _context.Users
                    on admin.applicationUserId equals user.Id
                join userRole in _context.UserRoles
                    on user.Id equals userRole.UserId
                join role in _context.Roles
                    on userRole.RoleId equals role.Id
                select new AdminDTO
                {
                    Id = admin.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Role = role.Name,
                    Salary = admin.Salary
                };
            return await query.ToListAsync();
        }

        public async Task<AdminDTO> GetByIdAsync(int Id)
        {
            var query =
                from admin in _context.Admins
                join user in _context.Users
                    on admin.applicationUserId equals user.Id
                join userRole in _context.UserRoles
                    on user.Id equals userRole.UserId
                join role in _context.Roles
                    on userRole.RoleId equals role.Id
                where admin.Id == Id
                select new AdminDTO
                {
                    Id = admin.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Role = role.Name,
                    Salary = admin.Salary,
                    ImageUrl = user.ImageUrl
                };
            var Admin = await query.SingleOrDefaultAsync();
            return  Admin ?? new AdminDTO();
        }

        public async Task<IEnumerable<AdminDTO>> SearchByNameAsync(string name)
        {
            var query =
               from admin in _context.Admins
               join user in _context.Users
                   on admin.applicationUserId equals user.Id
               join userRole in _context.UserRoles
                   on user.Id equals userRole.UserId
               join role in _context.Roles
                   on userRole.RoleId equals role.Id
               where user.FullName.ToLower()
                        .Contains(name.ToLower())
               select new AdminDTO
               {
                   Id = admin.Id,
                   FirstName = user.FirstName,
                   LastName = user.LastName,
                   UserName = user.UserName,
                   Role = role.Name,
                   Salary = admin.Salary
               };
            return await query.
                AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> UpdateAdminSalaryAsync(int adminId,decimal newSalary)
        {
            if (!await _context.Admins.AnyAsync(a => a.Id == adminId))
                return false;
            var admin = await _context.Admins.SingleAsync(a => a.Id == adminId);
            admin.Salary = newSalary;
            await _context.SaveChangesAsync();
            return admin.Salary == newSalary;
        }
    }
}
