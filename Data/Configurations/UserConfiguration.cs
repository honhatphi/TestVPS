using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackify.Data.Type;

namespace Trackify.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.ReferenceId).IsUnique();

        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:IdentityIncrement", 1)
            .HasAnnotation("SqlServer:IdentitySeed", 1000);

        builder.HasOne(i => i.Organization)
            .WithMany()
            .HasForeignKey(i => i.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(i => i.Username).IsUnique();
    }
}
