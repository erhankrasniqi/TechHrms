using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechHrms.Application.Commands.AdministrationCommands;
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
        private readonly IMapper _mapper;

        public EmployeesController(ILogger<EmployeesController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
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

            
            CreateEmployeeCommand command = _mapper.Map<CreateEmployeeCommand>(model);

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
                response.Items = _mapper.Map<List<EmployeeViewModel>>(result.Employees);
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
                    response = _mapper.Map<EmployeeViewModel>(result);
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
                    viewModel = _mapper.Map<ChangeEmployeeInfoFormModel>(result);
                }
            }

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeEmployeeInfo([FromForm] ChangeEmployeeInfoFormModel model)
        {
            ChangeEmployeePersonalInfoCommand command = _mapper.Map<ChangeEmployeePersonalInfoCommand>(model);

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
                    viewModel = _mapper.Map<DeleteEmployeePersonalInfoFromModel>(result);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeInfo([FromForm] DeleteEmployeePersonalInfoFromModel model)
        {
            DeleteEmployeePersonalInfoCommand command = _mapper.Map<DeleteEmployeePersonalInfoCommand>(model);

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
