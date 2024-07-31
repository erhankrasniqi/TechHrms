using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHrms.Application.Response;

namespace TechHrms.Application.Commands.HRRaportCommands
{
    public class CreateHRRaportCommand : IRequest<HRRaportResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? GeneratedOn { get; set; }
        public DateTime? GeneratedBy { get; set; }
        public string FilePath { get; set; }
    }
}
