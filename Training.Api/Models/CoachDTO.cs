using Training.Domain.Models;

namespace Training.Api.Models
{
    public class CoachDTO : EmployeeDTO
    {
        public int ExperienceYears { get; set; }
    }
}
