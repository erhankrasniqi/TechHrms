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
    public class DeleteAdministrationPersonalInfoCommandHandler : IRequestHandler<DeleteAdministrationPersonalInfoCommand, AdministrationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdministrationRepository _administrationRepository;

        public DeleteAdministrationPersonalInfoCommandHandler(IUnitOfWork unitOfWork, IAdministrationRepository administrationRepository)
        {
            _unitOfWork = unitOfWork;
            _administrationRepository = administrationRepository;
        }

        public async Task<AdministrationResponse> Handle(DeleteAdministrationPersonalInfoCommand request, CancellationToken cancellationToken = default)
        {
            Administration employee = await _administrationRepository.GetById(request.Id, cancellationToken).ConfigureAwait(false);
            AdministrationResponse response = null;

            if (employee != null)
            {
                _administrationRepository.Delete(employee);
                await _unitOfWork.Save(cancellationToken).ConfigureAwait(false);

                response = new() { Id = employee.Id, Message = "Administration information has been deleted." };
            }

            return response;
        }
    }
}
