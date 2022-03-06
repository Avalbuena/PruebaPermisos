using MediatR;
using Permissions.Infrastructure;
using System;

namespace Permissions.Domain.Application.Permit.Commands.UpdatePermit
{
    public class UpdatePermitCommand : IRequest<CommandResult>
    {
        public int PermitId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime PermitDate { get; set; }

        public int PermitTypeId { get; set; }
    }
}
