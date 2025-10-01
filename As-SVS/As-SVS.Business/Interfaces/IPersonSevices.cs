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
        Task<IEnumerable<PersonDTO>> GetAllAsync();
        Task<PersonDTO> GetByIdAsync(int id);
        Task<Person> AddNewAsync(PersonDTO DTO);
        Task<bool> UpdateAsync(PersonDTO entity);
        Task<bool> DeleteAsync(int id);
        Task<List<PersonDTO?>> FilterByName(string name);
        Task<List<PersonDTO?>> FilterByDOB(DateOnly dateOfBirth);
        Task<List<PersonDTO?>> FilterByGender(bool gender);
    }
}
