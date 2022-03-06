using Microsoft.EntityFrameworkCore;
using Permissions.Data.Permissions.Context;
using Permissions.Domain.Application.Permit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Data.Permissions.Repositories
{
    public class PermitRepository : IPermitRepository
    {

        private readonly PermissionsContext context;

        public PermitRepository(PermissionsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CreatePermit(Permit permit)
        {
            context.permits.Add(permit);

            return await context.SaveChangesAsync() > 0;
        }

        public Task<bool> DeletePermit(int permitId)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Permit>> GetAllPermit()
        {
            var permit = await context.permits
                                   .Include(c => c.PermitType)
                                   .OrderBy(a => a.Id)
                                   .ToListAsync();

            return permit;
        }

        public async Task<Permit> GetById(int permitId)
        {
            var permit = await context
                           .permits
                           .Include(c => c.PermitType)
                           .FirstOrDefaultAsync(c => c.Id.Equals(permitId));
            return permit;
        }

        public async Task<bool> UpdatePermit(Permit permit)
        {
            context.permits.Update(permit);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
