using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Queries.AdministrationQueries;
using TechHrms.Application.Queries.EmployeeQueries;
using TechHrms.Application.Response;
using TechHrms.WebApp.Models;
using TechHrms.WebApp.Models.Administration;
using TechHrms.WebApp.Models.Employees;

namespace TechHrms.WebApp.Controllers
{
    public class AdministrationController : Controller
    {

        private readonly ILogger<AdministrationController> _logger;
        private readonly IMediator _mediator;

        public AdministrationController(ILogger<AdministrationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterAdministration()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterAdministration([FromForm] RegisterAdministrationFormModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new InvalidEmailException("Invalid email address");
            //}

            CreateAdminstrationCommand command = new()
            {
                EmployeeId = model.EmployeeId,
                ApplicationDate = model.ApplicationDate,
                InterviewDate = model.InterviewDate,
                RecruiterName = model.RecruiterName,
                HiringStatus = model.HiringStatus,
                Notes = model.Notes,
                Salary = model.Salary,
                Position = model.Position,
                Department = model.Department,
            };

            AdministrationResponse response = await _mediator.Send(command).ConfigureAwait(false);

            AdminstrationConfirmationViewModel viewModel = new()
            {
                Success = true,
                AdministrationID = response.Id
            };

            return View("AdministrationConfirmation", viewModel);
        }

        public async Task<IActionResult> AdministrationList()
        {
            AdministrationListResponse result = await _mediator.Send(new AdministrationListQuery());
            ListViewModel<AdministrationViewModel> response = new();

            if (result != null && result.Administrations != null && result.Administrations.Any())
            {
                response.Items = result.Administrations.Select(x => new AdministrationViewModel
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId, 
                    ApplicationDate = x.ApplicationDate,
                    InterviewDate= x.InterviewDate,
                    RecruiterName= x.RecruiterName,
                    HiringStatus = x.HiringStatus,
                    Notes = x.Notes,
                    Salary = x.Salary,  
                    Position = x.Position,  
                    Department = x.Department
                    
                });
            }

            return View("AdministrationList", response);
        }

        public async Task<IActionResult> AdministrationDetail(int id)
        {
            AdministrationViewModel response = null;

            if (id > 0)
            {
                AdministrationByIdQuery query = new()
                {
                    Id = id
                };
                AdministrationDetailResponse result = await _mediator.Send(query);

                if (result != null)
                {
                    response = new()
                    {
                        Id = result.Id,
                        EmployeeId = result.EmployeeId,
                        ApplicationDate = result.ApplicationDate,
                        InterviewDate = result.InterviewDate,
                        Notes= result.Notes,
                        Salary= result.Salary,
                        Position = result.Position,
                        Department = result.Department

                    };
                }
            }

            return View(response);
        }


        public async Task<IActionResult> ChangeAdministrationInfo(int id)
        {
            ChangeAdministrationInfoModel viewModel = null;

            if (id > 0)
            {
                AdministrationByIdQuery query = new()
                {
                    Id = id
                };
                AdministrationDetailResponse result = await _mediator.Send(query);

                if (result != null)
                {
                    viewModel = new()
                    {
                        Id = result.Id,
                        Salary = result.Salary,
                        Position = result.Position,
                        Notes = result.Notes,
                    };
                }
            }

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeAdministrationInfo([FromForm] ChangeAdministrationInfoModel model)
        {
            ChangeAdmininstrationInfoCommand command = new()
            {
                Id = model.Id,
                Salary = model.Salary,
                Notes = model.Notes,
                Position = model.Position,
            };

            AdministrationResponse response = await _mediator.Send(command).ConfigureAwait(false);

            AdminstrationConfirmationViewModel viewModel = new()
            {
                Success = true,
                AdministrationID = response.Id
            };

            return View("ChangeAdministrationInfoConfirmation", viewModel);
        }

        public async Task<IActionResult> DeleteAdministrationInfo(int id)
        {
            DeleteAdministrationPersonalInfoFromModel viewModel = null;

            if (id > 0)
            {
                AdministrationByIdQuery query = new()
                {
                    Id = id
                };
                AdministrationDetailResponse result = await _mediator.Send(query);

                if (result != null)
                {
                    viewModel = new()
                    {
                        Id = result.Id,
                    };
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdministrationInfo([FromForm] DeleteAdministrationPersonalInfoFromModel model)
        {
            DeleteAdministrationPersonalInfoCommand command = new()
            {
                Id = model.Id
            };

            AdministrationResponse response = await _mediator.Send(command).ConfigureAwait(false);

            DeleteAdministrationConfirmationViewModel viewModel = new()
            {
                Success = true,
                EmployeeId = response.Id
            };

            return View("DeleteAdministrationConfirmation", viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
