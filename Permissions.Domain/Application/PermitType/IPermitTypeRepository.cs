using System.Collections.Generic;
using System.Threading.Tasks;

namespace Permissions.Domain.Application.PermitType
{
    public interface IPermitTypeRepository
    {
        Task<IReadOnlyList<PermitType>> GetPermitTypesAll();

        Task<PermitType> GetById(int permitTypeId);
    }
}
