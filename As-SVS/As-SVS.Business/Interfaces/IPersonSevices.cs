using As_SVS.Core.Models;
using As_SVS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IPersonSevices
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(int id);
        Task<Person> AddNewAsync(PersonDTO DTO);
        Task<bool> UpdateAsync(PersonDTO entity);
        Task<bool> UpdatePasswordAsync(int Id,string Password);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Person?>> FilterByName(string name);
        Task<IEnumerable<Person?>> FilterByDOB(DateOnly dateOfBirth);
        Task<IEnumerable<Person?>> FilterByGender(bool gender);
        Task<Person?> GetPersonByEmailAsync(string email);
    }
}
