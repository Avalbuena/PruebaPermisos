using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Permissions.Domain.Application.Permit.Queries.GetPermitById
{
    public class GetPermitByIdQueryHandler : IRequestHandler<GetPermitByIdQuery, PermitInfoDto>
    {
        private readonly IPermitRepository permitRepository;

        public GetPermitByIdQueryHandler(IPermitRepository permitRepository)
        {
            this.permitRepository = permitRepository ?? throw new ArgumentNullException(nameof(permitRepository));
        }

        public async Task<PermitInfoDto> Handle(GetPermitByIdQuery request, CancellationToken cancellationToken)
        {
            var permit = await permitRepository.GetById(request.PermitId);

            if (permit is null)
                return null;

            return new PermitInfoDto
            {
                FirstName = permit.FirstName,
                LastName = permit.LastName,
                PermitTypeId = permit.PermitType.Id,
                PermitTypeName = permit.PermitType.Description,
                PermitDate = permit.PermitDate.ToString("dd/MM/yyyy"),
                PermitId = permit.Id
            };
        }
    }
}
