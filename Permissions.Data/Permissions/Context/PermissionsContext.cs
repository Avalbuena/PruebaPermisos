using Microsoft.EntityFrameworkCore;
using Permissions.Data.Permissions.Configuration;
using Permissions.Domain.Application.Permit;
using Permissions.Domain.Application.PermitType;

namespace Permissions.Data.Permissions.Context
{
    public class PermissionsContext : DbContext
    {
        public PermissionsContext(DbContextOptions<PermissionsContext> options)
            : base(options) { }

        public DbSet<PermitType> permitTypes { get; set; }

        public DbSet<Permit> permits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermitTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermitConfiguration());

        }
    }
}
