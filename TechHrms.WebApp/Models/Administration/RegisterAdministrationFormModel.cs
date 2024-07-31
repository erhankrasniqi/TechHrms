using System;
using System.ComponentModel.DataAnnotations;

namespace TechHrms.WebApp.Models.Administration
{
    public class RegisterAdministrationFormModel
    {
        [Display(Name = "EmployeeId")]
        public string EmployeeId { get; set; }

        [Display(Name = "ApplicationDate")]
        public DateTime? ApplicationDate { get; set; }

        [Display(Name = "InterviewDate")]
        public DateTime? InterviewDate { get; set; }

        [Display(Name = "RecruiterName")]
        public string RecruiterName { get; set; }

        [Display(Name = "HiringStatus")]
        public string HiringStatus { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Salary")]
        public string Salary { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; }
    }
}
