using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Response;
using TechHrms.WebApp.Models.ProjectManagment;
using TechHrms.WebApp.Models;
using TechHrms.WebApp.Models.Training;
using TechHrms.Application.Commands.TrainingCommand;
using AutoMapper;
using TechHrms.Application.Commands.HRRaportCommands;

namespace TechHrms.WebApp.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ILogger<TrainingController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TrainingController(ILogger<TrainingController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
          

        public IActionResult RegisterTraining()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> RegisterTraining([FromForm] RegisterTrainingFormModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new InvalidEmailException("Invalid email address");
            //}
             

            CreateTrainingCommand command = _mapper.Map<CreateTrainingCommand>(model);

            TrainingResponse response = await _mediator.Send(command).ConfigureAwait(false);

            TrainingConfirmationViewModel viewModel = new()
            {
                Success = true,
                TrainingID = response.Id
            };

            return View("TrainingManagerConfirmation", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
