using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHrms.Application.Response;

namespace TechHrms.Application.Commands.AdministrationCommands
{
    public class DeleteAdministrationPersonalInfoCommand : IRequest<AdministrationResponse>
    {
        public int Id { get; set; }
    }
}
