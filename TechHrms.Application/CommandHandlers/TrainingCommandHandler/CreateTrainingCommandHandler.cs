using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Commands.TrainingCommand;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.CommandHandlers.TrainingCommandHandler
{
    public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, TrainingResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrainingRepository _trainingRepository;

        public CreateTrainingCommandHandler(IUnitOfWork unitOfWork, ITrainingRepository trainingRepository)
        {
            _unitOfWork = unitOfWork;
            _trainingRepository = trainingRepository;
        }

        public async Task<TrainingResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken = default)
        {
            Training pm = new()
            {
                Title = request.Title, 
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate, 

            };

            await _trainingRepository.Add(pm, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.Save(cancellationToken).ConfigureAwait(false);

            TrainingResponse response = new() { Id = pm.Id, Message = "Project Manager registered." };

            return response;
        }
    }
}
