using MediatR;
using Permissions.Domain.Application.PermitType;
using Permissions.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Permissions.Domain.Application.Permit.Commands.UpdatePermit
{
    public class UpdatePermitCommandHandler : IRequestHandler<UpdatePermitCommand, CommandResult>
    {
        private readonly IPermitRepository permitRepository;
        private readonly IPermitTypeRepository permitTypeRepository;


        public UpdatePermitCommandHandler(IPermitRepository permitRepository, IPermitTypeRepository permitTypeRepository)
        {
            this.permitRepository = permitRepository ?? throw new ArgumentNullException(nameof(permitRepository)); ;
            this.permitTypeRepository = permitTypeRepository ?? throw new ArgumentNullException(nameof(permitTypeRepository)); ;
        }

        public async Task<CommandResult> Handle(UpdatePermitCommand request, CancellationToken cancellationToken)
        {
            var permit = await permitRepository.GetById(request.PermitId);

            if (permit is null)
                return CommandResult.Fail(ErrorCodes.NotFound, "Permiso no encontrado.");

            var editPermitType = await permitTypeRepository.GetById(permit.PermitType.Id);

            permit.UpdatePermitInfo(
                    request.FirstName.ToUpperInvariant(),
                    request.LastName.ToUpperInvariant(),
                    editPermitType,
                    request.PermitDate);

            return await permitRepository.UpdatePermit(permit)
                ? CommandResult.Success()
                : CommandResult.Fail(ErrorCodes.NotFound, "Permiso no actualizado.");
        }
    }
}
