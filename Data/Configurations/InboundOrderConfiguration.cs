using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackify.Data.Type;

namespace Trackify.Data.Configurations;
public class InboundOrderConfiguration : IEntityTypeConfiguration<InboundOrder>
{
    public void Configure(EntityTypeBuilder<InboundOrder> builder)
    {
        builder.HasKey(i => i.Id);
        
        builder.HasIndex(i => i.ReferenceId).IsUnique();

        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd()
            .HasAnnotation("SqlServer:IdentityIncrement", 1)
            .HasAnnotation("SqlServer:IdentitySeed", 1000);

        builder.Property(i => i.CreatedAtUtc).HasDefaultValueSql("GETUTCDATE()");

        builder.Property(i => i.Status).HasConversion<int>();

        builder.HasOne(i => i.User)
            .WithMany()
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Period)
            .WithMany()
            .HasForeignKey(i => i.PeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Supplier)
            .WithMany()
            .HasForeignKey(i => i.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Partner)
            .WithMany()
            .HasForeignKey(i => i.PartnerId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(i => i.Project)
            .WithMany()
            .HasForeignKey(i => i.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(i => i.Code).IsUnique();
    }
}
