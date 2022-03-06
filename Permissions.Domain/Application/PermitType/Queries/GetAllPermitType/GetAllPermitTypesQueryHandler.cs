using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Permissions.Domain.Application.PermitType.Queries.GetAllPermitType
{
    public class GetAllPermitTypesQueryHandler : IRequestHandler<GetAllPermitTypesQuery, List<PermitTypeInfoDto>>
    {

        private readonly IPermitTypeRepository permitTypeRepository;

        public GetAllPermitTypesQueryHandler(IPermitTypeRepository permitTypeRepository)
        {
            this.permitTypeRepository = permitTypeRepository ?? throw new ArgumentNullException(nameof(permitTypeRepository)); ;
        }

        public async Task<List<PermitTypeInfoDto>> Handle(GetAllPermitTypesQuery request, CancellationToken cancellationToken)
        {
            var permitionType = await permitTypeRepository.GetPermitTypesAll();

            if (!permitionType.Any())
                return new List<PermitTypeInfoDto>();

            return permitionType.Select(c => new PermitTypeInfoDto
            {
                Id = c.Id,
                Description = c.Description
            }).ToList();
        }
    }
}
