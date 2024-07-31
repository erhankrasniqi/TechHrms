using System.ComponentModel.DataAnnotations;

namespace TechHrms.WebApp.Models.Employees
{
    public class RegisterEmployeeFormModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [Display(Name = "Skill")]
        public string Skill { get; set; }
        [Display(Name = "WorkExperience")]
        public string WorkExperience { get; set; }
    }
}
