using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackify.Data.Type;

namespace Trackify.Data.Configurations;
public class PalletMovementLogConfiguration : IEntityTypeConfiguration<PalletMovementLog>
{
    public void Configure(EntityTypeBuilder<PalletMovementLog> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.ReferenceId).IsUnique();

        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:IdentityIncrement", 1)
            .HasAnnotation("SqlServer:IdentitySeed", 1000);

        builder.HasOne(i => i.Pallet)
            .WithMany()
            .HasForeignKey(i => i.PalletId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.OriginOrder)
            .WithMany()
            .HasForeignKey(i => i.OriginOrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.SourceLocation)
            .WithMany()
            .HasForeignKey(i => i.SourceLocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.DestinationLocation)
            .WithMany()
            .HasForeignKey(i => i.DestinationLocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(i => i.OrderType).HasConversion<int>();

        builder.Property(i => i.Type).HasConversion<int>();

        builder.Property(i => i.Status).HasConversion<int>();
    }
}
