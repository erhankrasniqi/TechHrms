using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TechHrms.Application.Queries.EmployeeQueries;
using TechHrms.Application.Response;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Application.QueryHandlers.EmployeeQueryHandlers
{
    public class EmployeeByIdQueryHandler : IRequestHandler<EmployeeByIdQuery, EmployeeDetailResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDetailResponse> Handle(EmployeeByIdQuery query, CancellationToken cancellationToken = default)
        {
            Employee employee = await _employeeRepository.GetById(query.Id, cancellationToken).ConfigureAwait(false);
            EmployeeDetailResponse response = null;

            if (employee != null)
            {
                response = new()
                {
                    Id = employee.Id,
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName
                };
            }

            return response;
        }
    }
}
