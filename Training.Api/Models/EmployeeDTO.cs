namespace Training.Domain.Models
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime RollOnDate { get; set; }
        public string CommunityName { get; set; }
    }
}
