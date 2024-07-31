using System;

namespace TechHrms.WebApp.Models.Administration
{
    public class ChangeAdministrationInfoModel
    {
        public int Id { get; set; } 
        public string Notes { get; set; }
        public string Salary { get; set; }
        public string Position { get; set; }
    }
}
