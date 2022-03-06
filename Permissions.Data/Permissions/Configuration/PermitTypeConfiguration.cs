using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permissions.Domain.Application.PermitType;

namespace Permissions.Data.Permissions.Configuration
{
    public class PermitTypeConfiguration : IEntityTypeConfiguration<PermitType>
    {
        public void Configure(EntityTypeBuilder<PermitType> builder)
        {
            builder
                 .ToTable("PermitTypes")
                 .HasKey(c => c.Id);

            builder
                .Property(e => e.Description)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
