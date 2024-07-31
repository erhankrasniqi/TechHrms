using MediatR;
using TechHrms.Application.Response;

namespace TechHrms.Application.Queries.EmployeeQueries
{
    public class EmployeeByIdQuery : IRequest<EmployeeDetailResponse>
    {
        public int Id { get; set; }
    }
}
