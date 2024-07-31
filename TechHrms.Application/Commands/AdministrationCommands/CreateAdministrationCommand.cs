using MediatR;
using System;
using TechHrms.Application.Response;

namespace TechHrms.Application.Commands.AdministrationCommands
{
    public class CreateAdminstrationCommand : IRequest<AdministrationResponse>
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
