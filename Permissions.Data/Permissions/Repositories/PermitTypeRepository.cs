using Microsoft.EntityFrameworkCore;
using Permissions.Data.Permissions.Context;
using Permissions.Domain.Application.PermitType;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Permissions.Data.Permissions.Repositories
{
    public class PermitTypeRepository : IPermitTypeRepository
    {
        private readonly PermissionsContext context;

        public PermitTypeRepository(PermissionsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        public async Task<PermitType> GetById(int permitTypeId)
        {
            var permitType = await context.permitTypes.FirstOrDefaultAsync(c => c.Id.Equals(permitTypeId));

            return permitType;
        }

        public async Task<IReadOnlyList<PermitType>> GetPermitTypesAll()
        {
            return await context.permitTypes.ToListAsync();
        }
    }
}
