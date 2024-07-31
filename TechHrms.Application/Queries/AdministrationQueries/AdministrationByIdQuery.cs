using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHrms.Application.Response;

namespace TechHrms.Application.Queries.AdministrationQueries
{
    public class AdministrationByIdQuery : IRequest<AdministrationDetailResponse>
    {
        public int Id { get; set; }
    }
}
