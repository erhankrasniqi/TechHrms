using MediatR;
using TechHrms.Application.Response;

namespace TechHrms.Application.Commands.EmployeeCommands
{
    public class ChangeEmployeePersonalInfoCommand : IRequest<EmployeeResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
