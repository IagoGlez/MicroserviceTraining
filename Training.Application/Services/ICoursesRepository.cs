using Training.Domain.Entities;

namespace Training.Application.Services
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(Guid id);
        void DeleteCourse(Guid id);
        Task CreateCourse(Course course);
        Task UpdateCourse(Course course);
    }
}
