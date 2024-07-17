using Microsoft.EntityFrameworkCore;
using Training.Application.Services;
using Training.Domain.Entities;

namespace Training.Persistence.DbContexts
{
    public class CourseContext : DbContext, ICourseContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(new Course("IA", 200, DateTime.Now) { Id = Guid.NewGuid() },
                                                new Course("Ingles", 5000, DateTime.Now) { Id = Guid.NewGuid() },
                                                new Course("Microservicios", 30, DateTime.Now) { Id = Guid.NewGuid() });


            base.OnModelCreating(modelBuilder);
        }
    }
}
