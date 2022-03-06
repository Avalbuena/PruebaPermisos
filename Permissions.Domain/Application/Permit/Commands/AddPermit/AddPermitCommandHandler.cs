using MediatR;
using Permissions.Domain.Application.PermitType;
using Permissions.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Permissions.Domain.Application.Permit.Commands.AddPermit
{
    public class AddPermitCommandHandler : IRequestHandler<AddPermitCommand, CommandResult>
    {
        private readonly IPermitRepository permitRepository;
        private readonly IPermitTypeRepository permitTypeRepository;

        public AddPermitCommandHandler(IPermitRepository permitRepository, IPermitTypeRepository permitTypeRepository)
        {
            this.permitRepository = permitRepository ?? throw new ArgumentNullException(nameof(permitRepository)); ;
            this.permitTypeRepository = permitTypeRepository ?? throw new ArgumentNullException(nameof(permitTypeRepository)); ;
        }


        public async Task<CommandResult> Handle(AddPermitCommand request, CancellationToken cancellationToken)
        {

            PermitType.PermitType permitType = null;

            if (request.PermitType.HasValue)
            {
                var permitTypes = await permitTypeRepository.GetPermitTypesAll();
                var selectedPermitType = permitTypes.FirstOrDefault(c => c.Id == request.PermitType.Value);
                if (selectedPermitType != null)
                    permitType = selectedPermitType; 
            }

            var permit = new Permit(request.Name.ToUpperInvariant(), request.LastName.ToUpperInvariant(), permitType, request.PermitDate);

            var result = await permitRepository.CreatePermit(permit);

            return result ? CommandResult.Success() : CommandResult.Fail(ErrorCodes.InternalServerError, "No se ha podido crear el permiso.");

        }
    }
}
