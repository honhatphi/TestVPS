using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackify.Data.Type;

namespace Trackify.Data.Configurations;
public class StockLevelConfiguration : IEntityTypeConfiguration<StockLevel>
{
    public void Configure(EntityTypeBuilder<StockLevel> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.ReferenceId).IsUnique();

        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:IdentityIncrement", 1)
            .HasAnnotation("SqlServer:IdentitySeed", 1000);

        builder.Property(i => i.BeginningQuantity)
            .HasColumnType("decimal(18, 2)");

        builder.Property(i => i.InboundQuantity)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValue(0m);

        builder.Property(i => i.OtherInboundQuantity)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValue(0m);

        builder.Property(i => i.OutboundQuantity)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValue(0m);

        builder.Property(i => i.OtherOutboundQuantity)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValue(0m);

        builder.Property(i => i.EndingQuantity)
            .HasColumnType("decimal(18, 2)");

        builder.HasOne(i => i.Period)
           .WithMany()
           .HasForeignKey(i => i.PeriodId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Project)
            .WithMany()
            .HasForeignKey(i => i.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(i => new { i.PeriodId, i.ProductId }).IsUnique();

    }
}
