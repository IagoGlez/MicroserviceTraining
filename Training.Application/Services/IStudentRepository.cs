using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace Training.Application.Services
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(Guid id);
        void DeleteStudent(Guid id);
        Task CreateStudent(Student student);
        Task UpdateStudent(Student student);
    }
}
