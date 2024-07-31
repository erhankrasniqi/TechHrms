using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands; 
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.CommandHandlers.CreatePMCommandHandler
{
    public class CreatePMCommandHandler : IRequestHandler<CreatePMCommand, PMResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectManagmentRepository _pmRepository;

        public CreatePMCommandHandler(IUnitOfWork unitOfWork, IProjectManagmentRepository pmRepository)
        {
            _unitOfWork = unitOfWork;
            _pmRepository = pmRepository;
        }

        public async Task<PMResponse> Handle(CreatePMCommand request, CancellationToken cancellationToken = default)
        {
            ProjectManagment pm = new()
            {
                EmployeeId = request.EmployeeId,
                ProjectName = request.ProjectName,
                ClientName = request.ClientName,    
                Description = request.Description,  
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = request.Status 

            };

            await _pmRepository.Add(pm, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.Save(cancellationToken).ConfigureAwait(false);

            PMResponse response = new() { Id = pm.Id, Message = "Project Manager registered." };

            return response;
        }
    }
}
