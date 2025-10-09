using As_SVS.Business.Interfaces;
using As_SVS.Business.Services;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonSevices _personSevices;
        private readonly IAdminServices _adminServices;
        private readonly ITeacherServices _teacherServices;
        public AdminController(IPersonSevices personSevices, IAdminServices adminServices, ITeacherServices teacherServices, IMapper mapper)
        {
            _personSevices = personSevices;
            _adminServices = adminServices;
            _teacherServices = teacherServices;
            _mapper = mapper;
        }

        #region OnPerson

        [HttpGet("GetAll", Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPeopleAsync()
        {
            var peopleList = await _personSevices.GetAllAsync();
            var peopleListDTO = _mapper.Map<IEnumerable<PersonDTO>>(peopleList);
            if (peopleListDTO.Count() == 0)
                return NotFound("No people found");
            return Ok(peopleListDTO);
        }

        [HttpGet("{Id}", Name = "GetPersonById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPersonByIdAsync(int Id)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} is not valid");
            var person = await _personSevices.GetByIdAsync(Id);
            var personDTO = _mapper.Map<PersonDTO>(person);
            if (personDTO == null)
                return NotFound($"Person with ID {Id} dose not exist");
            return Ok(personDTO);
        }

        [HttpPatch("Update-Person/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePasswordAsync(int Id, string Password)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} is not valid");
            var person = await _personSevices.GetByIdAsync(Id);
            if (person == null)
                return NotFound($"Person with ID {Id} dose not exist");
            if (await _personSevices.UpdatePasswordAsync(Id,Password))
                return Ok("Password updated succesfully");
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update person");
        }

        [HttpDelete("Delete-Person/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePersonAsync(int Id)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} is not valid");
            var person = await _personSevices.GetByIdAsync(Id);
            if (person == null)
                return NotFound($"Person with ID {Id} dose not exist");
            if (await _personSevices.DeleteAsync(Id))
                return Ok(person);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete person");
        }

        [HttpGet("Filter-People-By-Name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterPeopleByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Name Is requiered");
            var peopleList = await _personSevices.FilterByName(name);
            var peopleListDTO = _mapper.Map<IEnumerable<PersonDTO>>(peopleList);
            if (peopleListDTO.Count() == 0)
                return NotFound($"No person with name {name} was found");
            return Ok(peopleListDTO);
        }

        [HttpGet("Filter-People-By-DOB/{DOB}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FiltePeopleByDOB(DateOnly DOB)
        {
            var peopleList = await _personSevices.FilterByDOB(DOB);
            var peopleListDTO = _mapper.Map<IEnumerable<PersonDTO>>(peopleList);
            if (peopleListDTO.Count() == 0)
                return NotFound($"No person with DOB {DOB.ToString()} was found");
            return Ok(peopleListDTO);
        }

        [HttpGet("Filter-People-By-Gender/{gender}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FiltePeopleByGender(string gender)
        {
            if (gender != "Male".ToLower() || gender != "Female".ToLower())
                return BadRequest("gender is either Male or Female");
            var peopleList = new List<Person>();
            switch (gender)
            {
                case "Male":
                    peopleList = (List<Person>)await _personSevices.FilterByGender(false);
                    break;
                case "Female":
                    peopleList = (List<Person>)await _personSevices.FilterByGender(true);
                    break;
            }
            var peopleListDTO = _mapper.Map<IEnumerable<PersonDTO>>(peopleList);
            if (peopleListDTO.Count() == 0)
                return NotFound("No person was found");
            return Ok(peopleListDTO);
        }

        [HttpPost("Assign-Role/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AssignRoleToPerson(int Id, string Role)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} Is not valid");
            var person = await _personSevices.GetByIdAsync(Id);
            var personDTO = _mapper.Map<PersonDTO>(person);
            if (personDTO == null)
                return NotFound($"Person with ID {Id} dose not exist");
            switch (Role)
            {
                case "Admin":
                    personDTO.Permission = PersonDTO.Permissions.Admin;
                    Admin admin = new Admin
                    {
                        PersonId = personDTO.Id,
                        Username = $"{personDTO.FirstName} + {Guid.NewGuid}",
                        Password = $"1234",
                        Salary = 4000,
                    };
                    await _adminServices.AssignRoleAsync<Admin>(admin);
                    break;
                case "Teacher":
                    personDTO.Permission = PersonDTO.Permissions.Teacher;
                    Teacher teacher = new Teacher
                    {
                        PersonId = personDTO.Id,
                        TeacherCode = $"T{personDTO.FirstName}e{Guid.NewGuid}",
                        Salary = 3500,
                        GradesId = 1,
                        Feedbacks = "none",
                        Specialization = "none",
                        NationalNumber = "none",
                        Qualifications = "none",
                    };
                    await _adminServices.AssignRoleAsync<Teacher>(teacher);
                    break;
                case "Student":
                    personDTO.Permission = PersonDTO.Permissions.Student;
                    Student student = new Student
                    {
                        PersonId = personDTO.Id,
                        StudentCode = $"S{personDTO.FirstName}t{Guid.NewGuid}",
                        Average = 0,
                        GradeId = 1,
                        MotherName = "Mother",
                    };
                    await _adminServices.AssignRoleAsync<Student>(student);
                    break;
            }
            return Ok($"{personDTO.FirstName} now has a role");
        }

        [HttpDelete("Diactivate-Role/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeactivatePersonRole(int Id)
        {
            if (Id < 1)
                return BadRequest("Invalid ID number");
            var person = await _personSevices.GetByIdAsync(Id);
            var personDTO = _mapper.Map<PersonDTO>(person);
            if (personDTO == null)
                return NotFound($"No person with ID {Id} was found");
            bool isDone = false;
            switch (personDTO.Permission)
            {
                case (PersonDTO.Permissions)Permissions.Admin:
                    await _adminServices.DeactivatePersonAsync(Id);
                    //Delete Admin Service
                    break;
                case (PersonDTO.Permissions)Permissions.Student:
                    await _adminServices.DeactivatePersonAsync(Id);
                    //Delete Student Service
                    break;
                case (PersonDTO.Permissions)Permissions.Teacher:
                    await _adminServices.DeactivatePersonAsync(Id);
                    Teacher? Teacher = await _teacherServices.GetByPersonIdAsync(Id);
                    isDone = await _teacherServices.DeleteAsync(Id);
                    break;
                default:
                    return BadRequest("Person has no Role");

            }
            if (isDone)
                return Ok($"person with ID {Id} deactivated succesfuly");
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to deactivate this person");
        }

        #endregion

        #region OnTeacher
        [HttpGet("All", Name = "Get-All-Teachers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            var teacherList = await _teacherServices.GetAllAsync();
            var teachetListDTO = _mapper.Map<IEnumerable<TeacherDTO>>(teacherList);
            if (teachetListDTO.Count() == 0)
                return NotFound("No teacher was found");
            return Ok(teachetListDTO);
        }

        [HttpGet("Get-Teacher-By-ID/{Id}", Name = "Get-Teacher-By-ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeacherByIdAsync(int Id)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} is not valid");
            var teacher = await _teacherServices.GetByIdAsync(Id);
            TeacherDTO? teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            if (teacher == null)
                return NotFound($"Teacher with ID {Id} was not found");
            return Ok(teacherDTO);
        }

        [HttpGet("Get-Teacher-By-Code/{code}", Name = "Get-Teacher-By-Code")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTeacherCodeAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest($"{code} is not valid");
            var teacher = await _teacherServices.GetByTeacherCode(code);
            TeacherDTO? teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            if (teacher == null)
                return NotFound($"Teacher with Code {code} was not found");
            return Ok(teacherDTO);
        }

        [HttpPatch("Update-Teacher-Salary/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateTeacherSalary(int Id,decimal salary)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} is not valid");
            bool isExist = await _teacherServices.IsExist(Id);
            if (!isExist)
                return NotFound($"teacher with ID {Id} dose not exist");
            bool isDone = await _teacherServices.UpdateSalaryAsync(Id, salary);
            if (!isDone)
                return StatusCode(StatusCodes.Status500InternalServerError,"An error accourd");
            return Ok("Salary updated succesfuly");
        }

        

        #endregion
    }
}
