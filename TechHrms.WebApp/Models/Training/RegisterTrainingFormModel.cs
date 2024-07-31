using System;
using System.ComponentModel.DataAnnotations;

namespace TechHrms.WebApp.Models.Training
{
    public class RegisterTrainingFormModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "StartDate")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "EndDate")]
        public DateTime? EndDate { get; set; }
    }
}
