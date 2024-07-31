using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using TechHrms.Application.CommandHandlers.AdministrationCommandHandler;
using TechHrms.Application.CommandHandlers.CreatePMCommandHandler;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Exceptions;
using TechHrms.Application.Queries.EmployeeQueries;
using TechHrms.Application.Response;
using TechHrms.WebApp.Models;
using TechHrms.WebApp.Models.Employees;
using TechHrms.WebApp.Models.Administration;

namespace TechHrms.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
          


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
