using MediatR;

namespace Permissions.Domain.Application.Permit.Queries.GetPermitById
{
    public class GetPermitByIdQuery : IRequest<PermitInfoDto>
    {
        public GetPermitByIdQuery(int permitId)
        {
            PermitId = permitId;
        }

        public int PermitId { get; }
    }
}
