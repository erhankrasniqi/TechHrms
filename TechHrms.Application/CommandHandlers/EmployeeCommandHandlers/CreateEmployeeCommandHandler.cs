using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.CommandHandlers.EmployeeCommandHandlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken = default)
        {
            Employee employee = new()
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Qualification =request.Qualification,
                Skill = request.Skill,
                WorkExperience = request.WorkExperience,
            };

            await _employeeRepository.Add(employee, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.Save(cancellationToken).ConfigureAwait(false);

            EmployeeResponse response = new() { Id = employee.Id, Message = "Employee registered." };

            return response;
        }
    }
}
