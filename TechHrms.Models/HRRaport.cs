using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHrms.Models
{
    public class HRRaport : BaseEntity
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? GeneratedOn { get; set; }
        public DateTime? GeneratedBy { get; set; }  
        public string FilePath { get; set; }  
    }
}
