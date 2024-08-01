using System;
using System.ComponentModel.DataAnnotations;

namespace TechHrms.WebApp.Models.HRRaport
{
    public class RegisterHRRaportFormModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "GeneratedOn")]
        public DateTime? GeneratedOn { get; set; }

        [Display(Name = "GeneratedBy")]
        public DateTime? GeneratedBy { get; set; }

        [Display(Name = "FilePath")]
        public string FilePath { get; set; }
    }
}
