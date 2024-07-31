using System;

namespace TechHrms.Models
{
    public class EmployeeWorkExperience : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
