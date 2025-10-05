using As_SVS.Core.Models;
using As_SVS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> FilterByName(string name);
        Task<List<Person>> FilterByDOB(DateOnly dateOfBirth);
        Task<List<Person>> FilterByGender(bool gender);
        Task<Person?> GetPersonByEmailAsync(string email);
    }
}
