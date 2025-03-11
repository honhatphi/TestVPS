using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackify.Data.Type;

namespace Trackify.Data.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.ReferenceId).IsUnique();

        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:IdentityIncrement", 1)
            .HasAnnotation("SqlServer:IdentitySeed", 1000);

        builder.Property(i => i.Type).HasConversion<int>();
    }
}
