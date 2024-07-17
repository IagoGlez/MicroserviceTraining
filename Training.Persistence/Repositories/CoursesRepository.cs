using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Training.Application.Services;
using Training.Domain.Entities;

namespace Training.Persistence.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private ICourseContext _context;

        public CoursesRepository(ICourseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _context.Courses.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void DeleteCourse(Guid id)
        {
            var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChangesAsync();
                //throw new ApplicationException("test");
            }
        }
        public async Task CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCourse(Course course)
        {
            var courseActualizar = await _context.Courses.Where(x => x.Id == course.Id).FirstOrDefaultAsync();
            if (courseActualizar != null)
            {
                courseActualizar.Name = course.Name;
                courseActualizar.MaxNumberOfStudents = course.MaxNumberOfStudents;
                courseActualizar.StartDate = course.StartDate;
            }

            await _context.SaveChangesAsync();
        }

    }
}
