using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly As_SVSContext _context;

        public UserRepository(As_SVSContext context)
        {
            _context = context;
        }

        #region Read
        public async Task<ApplicationUser> GetUserByIdAsync(string Id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == Id);
            if (user is null)
                return new ApplicationUser();
            return user;
        }
        #endregion

        #region Update
        public async Task<bool> UploadImageToDatabase(string fileName,string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.Id == userId);

            if (user is null)
                return false;

            user.ImageUrl = fileName;
            await _context.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}
