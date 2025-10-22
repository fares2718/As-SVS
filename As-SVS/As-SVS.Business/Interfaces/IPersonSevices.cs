using As_SVS.Core.Models;
using As_SVS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IPersonSevices : IBaseServices<Person>
    {
        Task<IEnumerable<Person?>> FilterByName(string name);
        Task<IEnumerable<Person?>> FilterByDOB(DateOnly dateOfBirth);
        Task<IEnumerable<Person?>> FilterByGender(bool gender);
        Task<Person?> GetPersonByEmailAsync(string email);
        Task<bool> UpdatePasswordAsync(int Id, string Password);
    }
}
