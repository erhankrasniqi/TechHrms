using System;
using System.ComponentModel.DataAnnotations;

namespace TechHrms.WebApp.Models.ProjectManagment
{
    public class RegisterProjectManagerFormModel
    {
        [Display(Name = "EmployeeId")]
        public string EmployeeId { get; set; }

        [Display(Name = "ProjectName")]
        public string ProjectName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "ClientName")]
        public string ClientName { get; set; }
    }
}
