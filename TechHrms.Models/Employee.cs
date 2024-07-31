namespace TechHrms.Models
{
    public class Employee : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string Skill { get; set; }
        public string WorkExperience { get; set; }
    }
}
