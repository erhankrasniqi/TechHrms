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

        public TrainingController(ILogger<TrainingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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

            CreateTrainingCommand command = new()
            {
                Title = model.Title, 
                Description = model.Description, 
                StartDate = model.StartDate,
                EndDate = model.EndDate, 

            };

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
