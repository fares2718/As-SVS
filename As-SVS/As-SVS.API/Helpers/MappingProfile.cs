using As_SVS.Core.Models;
using As_SVS.DTOs;
using AutoMapper;

namespace As_SVS.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();
            CreateMap<Admin, AdminDTO>();
            CreateMap<AdminDTO, Admin>();

        }
    }
}
