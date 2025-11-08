namespace As_SVS.Business.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterModel, ApplicationUser>();
            CreateMap<ApplicationUser, Admin>();
            CreateMap<AdminDTO, Admin>();
            CreateMap<ApplicationUser, Teacher>();
            CreateMap<TeacherDTO, Teacher>();
            CreateMap<TeacherProfile, Teacher>();
            CreateMap<ApplicationUser, Student>();
            CreateMap<StudentDTO, Student>();
            CreateMap<StudentProfile, Student>();
            CreateMap<ModuleDTO,As_SVS.Core.Models.Module>();
            CreateMap<LessonDTO,Lesson>();
            CreateMap<QuizeDTO,Quize>();
            CreateMap<QuizeQuestionDTO,QuizQuestion>();
            CreateMap<QuestionOptionDTO,QuestionOption>();
            CreateMap<QuizeAttempDTO,StudentQuizAttemp>();
        }
    }
}
