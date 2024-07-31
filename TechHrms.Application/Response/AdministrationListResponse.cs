using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHrms.Application.Response
{
    public class AdministrationListResponse
    {
        public IEnumerable<AdministrationDetailResponse> Administrations { get; set; }
    }
}
