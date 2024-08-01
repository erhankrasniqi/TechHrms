using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Commands.HRRaportCommands;
using TechHrms.Application.Exceptions;
using TechHrms.Application.Response;
using TechHrms.WebApp.Models;
using TechHrms.WebApp.Models.ProjectManagment;

namespace TechHrms.WebApp.Controllers
{
    public class ProjectManagmentController : Controller
    {
        private readonly ILogger<ProjectManagmentController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectManagmentController(ILogger<ProjectManagmentController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult RegisterProjectManager()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> RegisterProjectManager([FromForm] RegisterProjectManagerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidProjectNameException("Invalid project name");
            }

            CreatePMCommand command = _mapper.Map<CreatePMCommand>(model);

            PMResponse response = await _mediator.Send(command).ConfigureAwait(false);

            ProjectManagerConfirmationViewModel viewModel = new()
            {
                Success = true,
                ProjectID = response.Id
            };

            return View("ProjectManagerConfirmation", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
