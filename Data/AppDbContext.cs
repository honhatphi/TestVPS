using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Trackify.Data.Type;

namespace Trackify.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<InboundOrder> InboundOrders { get; set; }
    public DbSet<InboundOrderLine> InboundOrderLines { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OutboundOrder> OutboundOrders { get; set; }
    public DbSet<OutboundOrderLine> OutboundOrderLines { get; set; }
    public DbSet<Pallet> Pallets { get; set; }
    public DbSet<PalletContent> PalletContents { get; set; }
    public DbSet<PalletMovementLog> PalletMovementLogs { get; set; }
    public DbSet<PartnerProject> PartnerProjects { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SequenceNumber> SequenceNumbers { get; set; }
    public DbSet<StockLevel> StockLevels { get; set; }
    public DbSet<StockTakePeriod> StockTakePeriods { get; set; }
    public DbSet<SystemConfiguration> SystemConfigurations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WarehouseLocation> WarehouseLocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(w => w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS));

        optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.SaveChangesFailed));

        optionsBuilder.UseSnakeCaseNamingConvention();

        base.OnConfiguring(optionsBuilder);
    }
}
