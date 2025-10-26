using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.EF.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly As_SVSContext _context;
        public AdminRepository(As_SVSContext context)
        {
            _context = context;
        }
        public async Task AssignRoleAsync<T>(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivatePersonAsync(int Id)
        {
            var person = await _context.People.FindAsync(Id);
            if (person != null)
            {
                //person.Permission = Permissions.None;
                await _context.SaveChangesAsync();
            }
        }
    }
}
