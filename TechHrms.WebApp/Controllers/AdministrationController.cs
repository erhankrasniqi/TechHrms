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
        private readonly IMapper _mapper;

        public AdministrationController(ILogger<AdministrationController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
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
            CreateAdminstrationCommand command = _mapper.Map<CreateAdminstrationCommand>(model);

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
                response.Items = _mapper.Map<List<AdministrationViewModel>>(result.Administrations);
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
                    response = _mapper.Map<AdministrationViewModel>(result);
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
                    viewModel = _mapper.Map<ChangeAdministrationInfoModel>(result);
                }
            }

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeAdministrationInfo([FromForm] ChangeAdministrationInfoModel model)
        {
            if (!ModelState.IsValid)
            { 
                return View(model);
            }

            ChangeAdmininstrationInfoCommand command = _mapper.Map<ChangeAdmininstrationInfoCommand>(model);

            AdministrationResponse response = await _mediator.Send(command).ConfigureAwait(false);

            
            AdminstrationConfirmationViewModel viewModel = _mapper.Map<AdminstrationConfirmationViewModel>(response);

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
                    viewModel = _mapper.Map<DeleteAdministrationPersonalInfoFromModel>(result);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdministrationInfo([FromForm] DeleteAdministrationPersonalInfoFromModel model)
        {
            if (!ModelState.IsValid)
            { 
                return View(model);
            }
 
            DeleteAdministrationPersonalInfoCommand command = _mapper.Map<DeleteAdministrationPersonalInfoCommand>(model);

            AdministrationResponse response = await _mediator.Send(command).ConfigureAwait(false);
 
            DeleteAdministrationConfirmationViewModel viewModel = _mapper.Map<DeleteAdministrationConfirmationViewModel>(response);

            return View("DeleteAdministrationConfirmation", viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
