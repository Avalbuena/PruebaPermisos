using System.Collections.Generic;
using System.Threading.Tasks;

namespace Permissions.Domain.Application.Permit
{
    public interface IPermitRepository
    {
        Task<bool> CreatePermit(Permit permit);

        Task<Permit> GetById(int permitId);

        Task<bool> UpdatePermit(Permit permit);

        Task<bool> DeletePermit(int permitId);

        Task<IReadOnlyList<Permit>> GetAllPermit();

    }
}
