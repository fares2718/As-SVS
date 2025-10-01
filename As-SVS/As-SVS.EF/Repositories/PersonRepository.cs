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
    }
}
