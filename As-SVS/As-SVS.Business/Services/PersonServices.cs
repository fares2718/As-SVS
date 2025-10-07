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

        public async Task<Person> AddNewAsync(PersonDTO personDTO)
        {
            Person newPerson = _mapper.Map<Person>(personDTO);
            return await _baseRepository.AddNewAsync(newPerson);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           return await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var people = await _baseRepository.GetAllAsync();
            return people;
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            var person = await _baseRepository.GetByIdAsync(id);
            return person;
        }

        public async Task<bool> UpdateAsync(PersonDTO entity)
        {
            Person updatedEntity = _mapper.Map<Person>(entity);
            return await  _baseRepository.UpdateAsync(updatedEntity);
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
    }
}
