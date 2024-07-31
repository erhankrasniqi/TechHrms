using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHrms.Models
{
    public class Administration : BaseEntity
    {
        public string EmployeeId { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string RecruiterName { get; set; }
        public string HiringStatus { get; set; }
        public string Notes { get; set; }
        public string Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
      
        
    }
}
