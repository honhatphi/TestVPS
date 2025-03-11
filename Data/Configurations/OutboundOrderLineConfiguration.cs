using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackify.Data.Type;

namespace Trackify.Data.Configurations;
public class OutboundOrderLineConfiguration : IEntityTypeConfiguration<OutboundOrderLine>
{
    public void Configure(EntityTypeBuilder<OutboundOrderLine> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.ReferenceId).IsUnique();

        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:IdentityIncrement", 1)
            .HasAnnotation("SqlServer:IdentitySeed", 1000);

        builder.HasOne(i => i.OutboundOrder)
            .WithMany(i => i.OrderLines)
            .HasForeignKey(i => i.OutboundOrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(i => i.Quantity).HasColumnType("decimal(18, 2)");
    }
}