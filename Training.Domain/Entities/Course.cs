using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Entities
{
    public class Course
    {
        public Course() { } 

        public Course(string name, int maxNumberOfStudents, DateTime startDate)
        {
            Name = name;
            MaxNumberOfStudents = maxNumberOfStudents;
            StartDate = startDate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfStudents { get; set; }
        public DateTime StartDate { get; set; }

    }
}
