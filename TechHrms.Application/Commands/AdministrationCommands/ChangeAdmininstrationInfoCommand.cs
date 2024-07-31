using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHrms.Application.Response;

namespace TechHrms.Application.Commands.AdministrationCommands
{
    public class ChangeAdmininstrationInfoCommand : IRequest<AdministrationResponse>
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public string Notes { get; set; }
    }
}
