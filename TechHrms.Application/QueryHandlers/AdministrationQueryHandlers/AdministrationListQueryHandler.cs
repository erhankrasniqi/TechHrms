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
using TechHrms.Infrastructure.Repository;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.QueryHandlers.AdministrationQueryHandlers
{
    public class AdministrationListQueryHandler : IRequestHandler<AdministrationListQuery, AdministrationListResponse>
    {
        private readonly IAdministrationRepository _administrationRepository;

        public AdministrationListQueryHandler(IAdministrationRepository administrationRepository)
        {
            _administrationRepository = administrationRepository;
        }

        public async Task<AdministrationListResponse> Handle(AdministrationListQuery query, CancellationToken cancellationToken = default)
        {
            IEnumerable<Administration> administration = _administrationRepository.Get();
            AdministrationListResponse response = null;

            if (administration != null && administration.Any())
            {
                response = new()
                {
                    Administrations = administration.Select(x => new AdministrationDetailResponse
                    {
                        Id = x.Id,
                        EmployeeId = x.EmployeeId,
                        HiringStatus = x.HiringStatus,
                        ApplicationDate = x.ApplicationDate,
                        Position = x.Position,
                        Notes = x.Notes,
                        Salary = x.Salary,
                        Department = x.Department,
                        RecruiterName = x.RecruiterName,
                        InterviewDate = x.InterviewDate,
                    })
                };
            }

            return await Task.FromResult(response);
        }
    }
}
