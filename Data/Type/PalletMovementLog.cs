using Trackify.Data.Type.Abs;
using Trackify.Data.Type.Enums;

namespace Trackify.Data.Type;
public sealed class PalletMovementLog : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();

    public required int PalletId { get; init; }
    public Pallet Pallet { get; init; } = null!;

    public required int OrderId { get; init; }
    public required OrderType OrderType { get; set; }

    public required int OriginOrderId { get; init; }
    public InboundOrder OriginOrder { get; init; } = null!;

    public int? SourceLocationId { get; init; }
    public WarehouseLocation? SourceLocation { get; init; }

    public int? DestinationLocationId { get; init; }
    public WarehouseLocation? DestinationLocation { get; init; }

    public DateTime? StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public required MoveType Type { get; set; }
    public required MoveStatus Status { get; set; }
}
