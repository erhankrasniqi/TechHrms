using System.Collections.Generic;

namespace TechHrms.Application.Response
{
    public class EmployeeListResponse
    {
        public IEnumerable<EmployeeDetailResponse> Employees { get; set; }
    }
}
