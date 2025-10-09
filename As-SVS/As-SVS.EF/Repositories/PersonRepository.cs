using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.EF.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly As_SVSContext _context;
        public PersonRepository(As_SVSContext context)
        {
            _context = context;
        }
        public async Task<List<Person>> FilterByDOB(DateOnly dateOfBirth)
        {
            var filterResult = _context.People.Where(p=>p.DateOfBirth==dateOfBirth).ToListAsync();
            return await filterResult;
        }

        public async Task<List<Person>> FilterByGender(bool gender)
        {
            var filterResult = _context.People.Where(p => p.Gender == gender ).ToListAsync();
            return await filterResult;
        }

        public async Task<List<Person>> FilterByName(string name)
        {
            var filterResult = _context.People.Where(p=>p.FullName().Contains(name)).ToListAsync();
            return await filterResult;
        }

        public async Task<Person?> GetPersonByEmailAsync(string email)
        {
            var person = _context.People.FirstOrDefaultAsync(p => p.Email == email);
            return await person;
        }

        public async Task<bool> UpdatePasswordAsync(int Id, string Password)
        {
            Person? person = _context.People.FirstOrDefault(p => p.Id == Id);
            if(person != null)
                person.Password = Password;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
