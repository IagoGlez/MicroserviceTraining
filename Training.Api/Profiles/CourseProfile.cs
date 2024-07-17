using AutoMapper;

namespace Training.Domain.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Entities.Course, Models.CourseDTO>().ForMember(dest => dest.NameCourse, opt => opt.MapFrom(src => src.Name));
            CreateMap<Models.CourseDTO, Entities.Course>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameCourse));
            CreateMap<Entities.Student, Models.StudentDTO>();
            CreateMap<Models.StudentDTO, Entities.Student>();
            CreateMap<Entities.Coach, Models.CoachDTO>();
            CreateMap<Models.CoachDTO, Entities.Coach>();
        }
    }
}
