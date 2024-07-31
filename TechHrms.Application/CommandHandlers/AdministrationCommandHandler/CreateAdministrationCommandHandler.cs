using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.CommandHandlers.AdministrationCommandHandler
{
    public class CreateAdministrationCommandHandler : IRequestHandler<CreateAdminstrationCommand, AdministrationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdministrationRepository _administrationRepository;

        public CreateAdministrationCommandHandler(IUnitOfWork unitOfWork, IAdministrationRepository administrationRepository)
        {
            _unitOfWork = unitOfWork;
            _administrationRepository = administrationRepository;
        }

        public async Task<AdministrationResponse> Handle(CreateAdminstrationCommand request, CancellationToken cancellationToken = default)
        {
            Administration administration = new()
            {
                EmployeeId = request.EmployeeId,
                ApplicationDate = request.ApplicationDate,
                InterviewDate = request.InterviewDate,
                RecruiterName = request.RecruiterName,
                HiringStatus = request.HiringStatus,
                Notes = request.Notes,
                Salary = request.Salary,
                Position = request.Position,
                Department = request.Department,
            };

            await _administrationRepository.Add(administration, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.Save(cancellationToken).ConfigureAwait(false);

            AdministrationResponse response = new() { Id = administration.Id, Message = "Administration registered." };

            return response;
        }
    }
}
