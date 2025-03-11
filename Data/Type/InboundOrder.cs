using Trackify.Data.Type.Abs;
using Trackify.Data.Type.Enums;

namespace Trackify.Data.Type;
public sealed class InboundOrder : IEntity, IOwnedEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required int UserId { get; init; }
    public User User { get; init; } = null!;
    public required string Code { get; set; }
    public DateOnly PostingDate { get; private init; } = DateOnly.FromDateTime(DateTime.Now);
    public string? InvoiceNo { get; set; }
    public DateOnly? InvoiceDate { get; set; }
    public required int PeriodId { get; init; }
    public StockTakePeriod Period { get; init; } = null!;
    public required int SupplierId { get; init; }
    public Organization Supplier { get; init; } = null!;
    public required int PartnerId { get; init; }
    public Organization Partner { get; init; } = null!;
    public required int? ProjectId { get; init; }
    public PartnerProject? Project { get; init; }
    public required bool IsNonStorage { get; set; }
    public string? Notes { get; set; }
    public string? Reason { get; set; }
    public DateTime CreatedAtUtc { get; private init; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }
    public required OrderStatus Status { get; set; }
    public List<InboundOrderLine> OrderLines { get; set; } = [];
    public List<PalletContent> PalletContents { get; set; } = [];
}
