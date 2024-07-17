using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Training.Domain.Entities;

namespace Training.Application.Services
{
    public interface ICourseContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Coach> Coaches { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
