using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using AutoMapper;

namespace As_SVS.Business.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterModel, ApplicationUser>();
            CreateMap<ApplicationUser, Admin>();
            CreateMap<ApplicationUser, Teacher>();
            CreateMap<ApplicationUser, Student>();
            CreateMap<ModuleDTO,As_SVS.Core.Models.Module>();
            CreateMap<LessonDTO,Lesson>();
        }
    }
}
