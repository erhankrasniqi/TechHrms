using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Queries.EmployeeQueries;
using TechHrms.Application.Response;
using TechHrms.WebApp.Models;
using TechHrms.WebApp.Models.Employees;

namespace TechHrms.WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMediator _mediator;

        public EmployeesController(ILogger<EmployeesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee([FromForm] RegisterEmployeeFormModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new InvalidEmailException("Invalid email address");
            //}

            CreateEmployeeCommand command = new()
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Qualification = model.Qualification,
                Skill = model.Skill,
                WorkExperience = model.WorkExperience,
            };

            EmployeeResponse response = await _mediator.Send(command).ConfigureAwait(false);

            EmployeeConfirmationViewModel viewModel = new()
            {
                Success = true,
                EmployeeId = response.Id
            };

            return View("EmployeeConfirmation", viewModel);
        }

        public async Task<IActionResult> EmployeeList()
        {
            EmployeeListResponse result = await _mediator.Send(new EmployeeListQuery());
            ListViewModel<EmployeeViewModel> response = new();

            if (result != null && result.Employees != null && result.Employees.Any())
            {
                response.Items = result.Employees.Select(x => new EmployeeViewModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                });
            }

            return View("EmployeeList", response);
        }

        public async Task<IActionResult> EmployeeDetail(int id)
        {
            EmployeeViewModel response = null;

            if (id > 0)
            {
                EmployeeByIdQuery query = new()
                {
                    Id = id
                };
                EmployeeDetailResponse result = await _mediator.Send(query);

                if (result != null)
                {
                    response = new()
                    {
                        Id = result.Id,
                        Email = result.Email,
                        FirstName = result.FirstName,
                        LastName = result.LastName
                    };
                }
            }

            return View(response);
        }

        public async Task<IActionResult> ChangeEmployeeInfo(int id)
        {
            ChangeEmployeeInfoFormModel viewModel = null;

            if (id > 0)
            {
                EmployeeByIdQuery query = new()
                {
                    Id = id
                };
                EmployeeDetailResponse result = await _mediator.Send(query);

                if (result != null)
                {
                    viewModel = new()
                    {
                        Id = result.Id,
                        FirstName = result.FirstName,
                        LastName = result.LastName
                    };
                }
            }

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeEmployeeInfo([FromForm] ChangeEmployeeInfoFormModel model)
        {
            ChangeEmployeePersonalInfoCommand command = new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            EmployeeResponse response = await _mediator.Send(command).ConfigureAwait(false);

            EmployeeConfirmationViewModel viewModel = new()
            {
                Success = true,
                EmployeeId = response.Id
            };

            return View("ChangeEmployeeInfoConfirmation", viewModel);
        }


        public async Task<IActionResult> DeleteEmployeeInfo(int id)
        {
            DeleteEmployeePersonalInfoFromModel viewModel = null;

            if (id > 0)
            {
                EmployeeByIdQuery query = new()
                {
                    Id = id
                };
                EmployeeDetailResponse result = await _mediator.Send(query);

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
        public async Task<IActionResult> DeleteEmployeeInfo([FromForm] DeleteEmployeePersonalInfoFromModel model)
        {
            DeleteEmployeePersonalInfoCommand command = new()
            {
                Id = model.Id
            };

            EmployeeResponse response = await _mediator.Send(command).ConfigureAwait(false);

            DeleteConfirmationViewModel viewModel = new()
            {
                Success = true,
                EmployeeId = response.Id
            };

            return View("DeleteEmployeeInfoConfirmation", viewModel);
        }

        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
