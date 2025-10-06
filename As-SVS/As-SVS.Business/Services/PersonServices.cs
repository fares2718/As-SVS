using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Services
{
    public class PersonServices : IPersonSevices
    {
        private readonly IBaseRepository<Person> _baseRepository;
        private readonly IPersonRepository _personRepository;
        public PersonServices(IBaseRepository<Person> baseRepository, IPersonRepository personRepository)
        {
            _baseRepository = baseRepository;
            _personRepository = personRepository;
        }
        private Person? MapDTO(PersonDTO personDTO)
        {
            if(personDTO!=null)
            {
                return new Person
                {
                    FirstName = personDTO.FirstName,
                    MiddleName = personDTO.MiddleName,
                    LastName = personDTO.LastName,
                    Email = personDTO.Email,
                    Password = personDTO.Password,
                    DateOfBirth = personDTO.DateOfBirth,
                    ImageUrl = personDTO.ImageUrl,
                    Phone = personDTO.Phone,
                    Permission = (Permissions)personDTO.Permission,
                    Gender = personDTO.Gender,
                    Id = personDTO.Id
                };
            }
            return null;
        }
        private PersonDTO? MapDTO(Person person)
        {
            if (person != null)
            {
                return new PersonDTO
                {
                    FirstName = person.FirstName,
                    MiddleName = person.MiddleName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Password = person.Password,
                    DateOfBirth = person.DateOfBirth,
                    ImageUrl = person.ImageUrl,
                    Phone = person.Phone,
                    Permission = (PersonDTO.Permissions)person.Permission,
                    Gender = person.Gender,
                    Id = person.Id
                };

            }
            else
                return null;
        }


        public async Task<Person> AddNewAsync(PersonDTO personDTO)
        {
            Person newPerson = MapDTO(personDTO);
            return await _baseRepository.AddNewAsync(newPerson);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           return await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PersonDTO>> GetAllAsync()
        {
            var people = await _baseRepository.GetAllAsync();
            List<PersonDTO?> personDTOs = people.Select(p => MapDTO(p)).ToList();
            return personDTOs;
        }

        public async Task<PersonDTO> GetByIdAsync(int id)
        {
            var person = await _baseRepository.GetByIdAsync(id);
            PersonDTO? personDTO = MapDTO(person);
            return personDTO;
        }

        public async Task<bool> UpdateAsync(PersonDTO entity)
        {
            Person? updatedEntity = MapDTO(entity);
           return await  _baseRepository.UpdateAsync(updatedEntity);
        }

        public async Task<IEnumerable<PersonDTO?>> FilterByName(string name)
        {
            var filterResult = await _personRepository.FilterByName(name);
            List<PersonDTO?> filterResultDTO =  filterResult.Select(p => MapDTO(p)).ToList();
            return filterResultDTO;
        }

        public async Task<IEnumerable<PersonDTO?>> FilterByDOB(DateOnly dateOfBirth)
        {
            var filterResult = await _personRepository.FilterByDOB(dateOfBirth);
            List<PersonDTO?> filterResultDTO = filterResult.Select(p => MapDTO(p)).ToList();
            return filterResultDTO;
        }

        public async Task<IEnumerable<PersonDTO?>> FilterByGender(bool gender)
        {
            var filterResult = await _personRepository.FilterByGender(gender);
            List<PersonDTO?> filterResultDTO = filterResult.Select(p => MapDTO(p)).ToList();
            return filterResultDTO;
        }

        public async Task<PersonDTO?> GetPersonByEmailAsync(string email)
        {
            Person? person = await _personRepository.GetPersonByEmailAsync(email);
            PersonDTO? personDTO = MapDTO(person);
            return personDTO;
        }
    }
}
