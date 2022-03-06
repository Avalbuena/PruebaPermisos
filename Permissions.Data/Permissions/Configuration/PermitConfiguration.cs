using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permissions.Domain.Application.Permit;

namespace Permissions.Data.Permissions.Configuration
{
    public class PermitConfiguration : IEntityTypeConfiguration<Permit>
    {
        public void Configure(EntityTypeBuilder<Permit> builder)
        {
            builder
               .ToTable("Permissions")
               .HasKey(c => c.Id);

            builder
              .Property(c => c.FirstName)
              .IsRequired()
              .HasMaxLength(128);

            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(e => e.PermitDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder
                .HasOne(c => c.PermitType)
                .WithMany();
        }
    }
}
