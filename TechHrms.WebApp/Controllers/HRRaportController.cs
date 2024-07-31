using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TechHrms.Application.Commands.TrainingCommand;
using TechHrms.Application.Response;
using TechHrms.WebApp.Models.Training;
using TechHrms.WebApp.Models;
using TechHrms.WebApp.Models.HRRaport;
using TechHrms.Application.Commands.HRRaportCommands;

namespace TechHrms.WebApp.Controllers
{
    public class HRRaportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ILogger<HRRaportController> _logger;
        private readonly IMediator _mediator;

        public HRRaportController(ILogger<HRRaportController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        public IActionResult RegisterHRRaport()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> RegisterHRRaport([FromForm] RegisterHRRaportFormModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new InvalidEmailException("Invalid email address");
            //}

            CreateHRRaportCommand command = new()
            {
                Title = model.Title,
                Description = model.Description,
                GeneratedBy = model.GeneratedOn,
                GeneratedOn = model.GeneratedOn,
                FilePath = model.FilePath,

            };

            HRRaportResponse response = await _mediator.Send(command).ConfigureAwait(false);

            HRRaportConfirmationViewModel viewModel = new()
            {
                Success = true,
                RaportID = response.Id
            };

            return View("HRRaportConfirmation", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
