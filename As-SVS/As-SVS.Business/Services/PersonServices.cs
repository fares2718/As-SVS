using As_SVS.API.Helpers;
using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Person> _baseRepository;
        private readonly IPersonRepository _personRepository;
        public PersonServices(IBaseRepository<Person> baseRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }
       
        #region Creat
        public async Task<int> AddNewAsync(Person newPerson)
        {
            //newPerson.Permission = Permissions.None;
            newPerson.Password = Cryptography.ComputeHash(newPerson.Password);
            await _baseRepository.AddNewAsync(newPerson);
            return newPerson.Id;
        }
        #endregion

        #region Read
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var people = await _baseRepository.GetAllAsync();
            return people;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            Person? person = await _baseRepository.GetByIdAsync(id);
            return person;
        }

        public async Task<IEnumerable<Person?>> FilterByName(string name)
        {
            var filterResult = await _personRepository.FilterByName(name);
            return filterResult;
        }

        public async Task<IEnumerable<Person?>> FilterByDOB(DateOnly dateOfBirth)
        {
            var filterResult = await _personRepository.FilterByDOB(dateOfBirth);
            return filterResult;
        }

        public async Task<IEnumerable<Person?>> FilterByGender(bool gender)
        {
            var filterResult = await _personRepository.FilterByGender(gender);
            return filterResult;
        }

        public async Task<Person?> GetPersonByEmailAsync(string email)
        {
            Person? person = await _personRepository.GetPersonByEmailAsync(email);
            return person;
        }
        #endregion

        #region Update
        public async Task<bool> UpdateAsync(Person person)
        {
            return await _baseRepository.UpdateAsync(person);
        }
        public async Task<bool> UpdatePasswordAsync(int Id, string Password)
        {
            Password = Cryptography.ComputeHash(Password);
            return await _personRepository.UpdatePasswordAsync(Id, Password);
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteAsync(int id)
        {
           return await _baseRepository.DeleteAsync(id);
        }
        #endregion

    }
}
