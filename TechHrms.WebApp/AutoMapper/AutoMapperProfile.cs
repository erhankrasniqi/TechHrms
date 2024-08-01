using AutoMapper;
using Microsoft.Extensions.Logging;
using TechHrms.Application.Commands.AdministrationCommands;
using TechHrms.Application.Commands.EmployeeCommands;
using TechHrms.Application.Commands.HRRaportCommands;
using TechHrms.Application.Commands.TrainingCommand;
using TechHrms.Application.Response;
using TechHrms.Models;
using TechHrms.WebApp.Models.Administration;
using TechHrms.WebApp.Models.Employees;
using TechHrms.WebApp.Models.HRRaport;
using TechHrms.WebApp.Models.ProjectManagment;
using TechHrms.WebApp.Models.Training;

namespace TechHrms.WebApp.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterHRRaportFormModel, CreateHRRaportCommand>();
            CreateMap<RegisterProjectManagerFormModel, CreatePMCommand>();
            CreateMap<RegisterTrainingFormModel, CreateTrainingCommand>();
            CreateMap<RegisterEmployeeFormModel, CreateEmployeeCommand>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeDetailResponse, EmployeeViewModel>();
            CreateMap<EmployeeDetailResponse, ChangeEmployeeInfoFormModel>();
            CreateMap<ChangeEmployeeInfoFormModel, ChangeEmployeePersonalInfoCommand>();
            CreateMap<EmployeeDetailResponse, DeleteEmployeePersonalInfoFromModel>();
            CreateMap<DeleteEmployeePersonalInfoFromModel, DeleteEmployeePersonalInfoCommand>();

            CreateMap<Administration, AdministrationViewModel>();
            CreateMap<RegisterAdministrationFormModel, CreateAdminstrationCommand>();
            CreateMap<AdministrationResponse, AdminstrationConfirmationViewModel>(); 
            CreateMap<AdministrationDetailResponse, AdministrationViewModel>();
            CreateMap<AdministrationDetailResponse, ChangeAdministrationInfoModel>(); 
            CreateMap<ChangeAdministrationInfoModel, ChangeAdmininstrationInfoCommand>(); 
            CreateMap<AdministrationDetailResponse, DeleteAdministrationPersonalInfoFromModel>(); 
            CreateMap<DeleteAdministrationPersonalInfoFromModel, DeleteAdministrationPersonalInfoCommand>();
            CreateMap<AdministrationResponse, DeleteAdministrationConfirmationViewModel>();


        }
    }
}