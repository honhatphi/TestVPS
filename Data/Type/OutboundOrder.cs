using Trackify.Data.Type.Abs;
using Trackify.Data.Type.Enums;

namespace Trackify.Data.Type;
public class OutboundOrder : IEntity, IOwnedEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required int UserId { get; init; }
    public User User { get; init; } = null!;

    public required string Code { get; set; }
    public DateOnly PostingDate { get; private init; } = DateOnly.FromDateTime(DateTime.Now);
    public required int PeriodId { get; init; }
    public StockTakePeriod Period { get; init; } = null!;
    public required int CustomerId { get; init; }
    public Organization Customer { get; init; } = null!;
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
    public List<OutboundOrderLine> OrderLines { get; set; } = [];
}
