namespace Training.Domain.Models
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string NameCourse { get; set; }
        public int MaxNumberOfStudents { get; set; }
        public DateTime StartDate { get; set; }
    }
}
