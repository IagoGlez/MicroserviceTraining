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

        void Dispose();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<T> Set<T>() where T : class;
    }
}
