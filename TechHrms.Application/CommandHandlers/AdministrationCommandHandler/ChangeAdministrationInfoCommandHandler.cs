using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.CommandHandlers.AdministrationCommandHandler
{
    public class ChangeAdministrationInfoCommandHandler : IRequestHandler<ChangeAdmininstrationInfoCommand, AdministrationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdministrationRepository _administratorRepository;

        public ChangeAdministrationInfoCommandHandler(IUnitOfWork unitOfWork, IAdministrationRepository administratorRepository)
        {
            _unitOfWork = unitOfWork;
            _administratorRepository = administratorRepository;
        }

        public async Task<AdministrationResponse> Handle(ChangeAdmininstrationInfoCommand request, CancellationToken cancellationToken = default)
        {
            Administration employee = await _administratorRepository.GetById(request.Id, cancellationToken).ConfigureAwait(false);
            AdministrationResponse response = null;

            if (employee != null)
            {
                employee.Salary = request.Salary;
                employee.Position = request.Position;
                employee.Notes = request.Notes;

                _administratorRepository.Update(employee); 
                await _unitOfWork.Save(cancellationToken).ConfigureAwait(false);

                response = new() { Id = employee.Id, Message = "Administration personal information has been changed." };
            }

            return response;
        }
    }
}
