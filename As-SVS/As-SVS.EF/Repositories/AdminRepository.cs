using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class AdminRepository : IBaseRepository<Admin>
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

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admins
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Admin> GetByIdAsync(int Id)
        {
            var admin = await _context.Admins.SingleOrDefaultAsync(a => a.Id == Id);
            if(admin is null)
                return new Admin();
            return admin;
        }

        public async Task<IEnumerable<Admin>> SearchByNameAsync(string name)
        {
            var adminsList = await _context.Admins
                .Where(a => a.applicationUser.FullName.Contains(name))
                .AsNoTracking()
                .ToListAsync();
            if(adminsList is null)
                return Enumerable.Empty<Admin>();
            return adminsList;
        }
    }
}
