using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Permissions.Domain.Application.Permit.Queries.GetAllPermit
{
    public class GetAllPermitQueryHandler : IRequestHandler<GetAllPermitQuery, List<PermitInfoDto>>
    {
        private readonly IPermitRepository permitRepository;

        public GetAllPermitQueryHandler(IPermitRepository permitRepository)
        {
            this.permitRepository = permitRepository ?? throw new ArgumentNullException(nameof(permitRepository)); 
        }

        public async Task<List<PermitInfoDto>> Handle(GetAllPermitQuery request, CancellationToken cancellationToken)
        {
            var permit = await permitRepository.GetAllPermit();

            if (!permit.Any())
                return new List<PermitInfoDto>();

            return permit.Select(u => new PermitInfoDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                PermitTypeId = u.PermitType.Id,
                PermitTypeName = u.PermitType.Description,
                PermitDate = u.PermitDate.ToString("dd/MM/yyyy"),
                PermitId =u.Id
            }).ToList();
        }
    }
}
