using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Application.Services;
using Training.Domain.Entities;

namespace Training.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private ICourseContext _context;

        public StudentRepository(ICourseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            return await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void DeleteStudent(Guid id)
        {
            var student = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChangesAsync();
                throw new ApplicationException("test");
            }
        }

        public async Task CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStudent(Student student)
        {
            var studentActualizar = await _context.Students.Where(x => x.Id == student.Id).FirstOrDefaultAsync();
            if (studentActualizar != null)
            {
                studentActualizar.Name = student.Name;
                studentActualizar.HoursTaken = student.HoursTaken;
                studentActualizar.EmailAddress = student.EmailAddress;
                studentActualizar.RollOnDate = student.RollOnDate;
                studentActualizar.CommunityName = student.CommunityName;
            }

            await _context.SaveChangesAsync();
        }
    }
}
