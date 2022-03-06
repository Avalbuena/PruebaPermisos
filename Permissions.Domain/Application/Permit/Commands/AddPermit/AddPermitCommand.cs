using MediatR;
using Permissions.Infrastructure;
using System;

namespace Permissions.Domain.Application.Permit.Commands.AddPermit
{
    public class AddPermitCommand : IRequest<CommandResult>
    {

        public string Name { get; set; }

        public string LastName { get; set; }

        public int? PermitType { get; set; }

        public DateTime PermitDate { get; set; }
    }
}
    