using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Queries.AdministrationQueries;
using TechHrms.Application.Queries.EmployeeQueries;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.QueryHandlers.AdministrationQueryHandlers
{
    public class AdministrationByIdQueryHandler : IRequestHandler<AdministrationByIdQuery, AdministrationDetailResponse>
    {
        private readonly IAdministrationRepository _employeeRepository;

        private readonly IAdministrationRepository _administrationRepository;

        public AdministrationByIdQueryHandler(IAdministrationRepository administrationRepository)
        {
            _administrationRepository = administrationRepository;
        }

        public async Task<AdministrationDetailResponse> Handle(AdministrationByIdQuery query, CancellationToken cancellationToken = default)
        {
            Administration administration = await _administrationRepository.GetById(query.Id, cancellationToken).ConfigureAwait(false);
            AdministrationDetailResponse response = null;

            if (administration != null)
            {
                response = new()
                {
                    Id = administration.Id,
                    Notes = administration.Notes,
                    HiringStatus = administration.HiringStatus,
                    RecruiterName = administration.RecruiterName,
                    InterviewDate = administration.InterviewDate,
                    ApplicationDate = administration.ApplicationDate,
                    EmployeeId = administration.EmployeeId,
                    Department = administration.Department,
                    Position = administration.Position,
                    Salary = administration.Salary
                };
            }

            return response;
        }
    }
}
