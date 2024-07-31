using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Commands.HRRaportCommands;
using TechHrms.Application.Commands.TrainingCommand;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.CommandHandlers.HRRaportCommandHandlers
{
    public class CreateHRRaportCommandHandler : IRequestHandler<CreateHRRaportCommand, HRRaportResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHRRaportRepository _hrraportRepository;

        public CreateHRRaportCommandHandler(IUnitOfWork unitOfWork, IHRRaportRepository hrraportRepository)
        {
            _unitOfWork = unitOfWork;
            _hrraportRepository = hrraportRepository;
        }

        public async Task<HRRaportResponse> Handle(CreateHRRaportCommand request, CancellationToken cancellationToken = default)
        {
            HRRaport pm = new()
            {
                Title = request.Title,
                Description = request.Description,
                GeneratedOn = request.GeneratedOn,
                GeneratedBy = request.GeneratedBy,
                FilePath = request.FilePath,

            };

            await _hrraportRepository.Add(pm, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.Save(cancellationToken).ConfigureAwait(false);

            HRRaportResponse response = new() { Id = pm.Id, Message = "Raport registered." };

            return response;
        }
    }
}
