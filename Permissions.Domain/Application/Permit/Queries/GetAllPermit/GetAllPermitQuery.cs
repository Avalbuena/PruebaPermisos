using MediatR;
using System.Collections.Generic;

namespace Permissions.Domain.Application.Permit.Queries.GetAllPermit
{
    public class GetAllPermitQuery : IRequest<List<PermitInfoDto>>
    {

    }
}
