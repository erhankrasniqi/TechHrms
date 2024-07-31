using System;

namespace TechHrms.Models
{
    public class EmployeeQualification : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Qualification { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
