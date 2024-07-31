using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.CommandHandlers.EmployeeCommandHandlers
{
    public class ChangeEmployeePersonalInfoCommandHandler : IRequestHandler<ChangeEmployeePersonalInfoCommand, EmployeeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;

        public ChangeEmployeePersonalInfoCommandHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(ChangeEmployeePersonalInfoCommand request, CancellationToken cancellationToken = default)
        {
            Employee employee = await _employeeRepository.GetById(request.Id, cancellationToken).ConfigureAwait(false);
            EmployeeResponse response = null;

            if (employee != null)
            {
                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;

                _employeeRepository.Update(employee);
                //_employeeRepository.Delete(employee);
                await _unitOfWork.Save(cancellationToken).ConfigureAwait(false);

                response = new() { Id = employee.Id, Message = "Employee personal information has been changed." };
            }

            return response;
        }
    }
}
