using MediatR;
using System;
using TechHrms.Application.Response;

namespace TechHrms.Application.Commands.AdministrationCommands
{
    public class CreatePMCommand : IRequest<PMResponse>
    {
        public string EmployeeId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string ClientName { get; set; } 
    }
}
