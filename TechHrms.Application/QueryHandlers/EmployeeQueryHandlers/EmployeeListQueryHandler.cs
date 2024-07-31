using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Application.Queries.EmployeeQueries;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.QueryHandlers.EmployeeQueryHandlers
{
    public class EmployeeListQueryHandler : IRequestHandler<EmployeeListQuery, EmployeeListResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeListQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeListResponse> Handle(EmployeeListQuery query, CancellationToken cancellationToken = default)
        {
            IEnumerable<Employee> employees = _employeeRepository.Get();
            EmployeeListResponse response = null;

            if (employees != null && employees.Any())
            {
                response = new()
                {
                    Employees = employees.Select(x => new EmployeeDetailResponse
                    {
                        Id = x.Id,
                        Email = x.Email,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                    })
                };
            }

            return await Task.FromResult(response);
        }
    }
}
