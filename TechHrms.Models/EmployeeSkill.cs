namespace TechHrms.Models
{
    public class EmployeeSkill : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Skill { get; set; }
        public int? YearsOfExperience { get; set; }
    }
}
