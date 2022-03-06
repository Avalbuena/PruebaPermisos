using MediatR;
using System.Collections.Generic;

namespace Permissions.Domain.Application.PermitType.Queries.GetAllPermitType
{
    public class GetAllPermitTypesQuery : IRequest<List<PermitTypeInfoDto>>
    {
    }
}
