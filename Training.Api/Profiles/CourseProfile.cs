using AutoMapper;

namespace Training.Domain.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Entities.Course, Models.CourseDTO>();
            CreateMap<Models.CourseDTO, Entities.Course>();
            CreateMap<Entities.Student, Models.StudentDTO>();
            CreateMap<Models.StudentDTO, Entities.Student>();
            CreateMap<Entities.Coach, Models.CoachDTO>();
            CreateMap<Models.CoachDTO, Entities.Coach>();
        }
    }
}
