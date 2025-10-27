using As_SVS.Core.Models;
using AutoMapper;

namespace As_SVS.Business.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterModel, ApplicationUser>();
        }
    }
}
