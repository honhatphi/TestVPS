using Trackify.Data.Type.Abs;
using Trackify.Data.Type.Enums;

namespace Trackify.Data.Type;
public sealed class Pallet : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();

    public required string Code { get; set; }
    public required int OrderNumber { get; set; }
    public int? LocationId { get; init; }
    public WarehouseLocation? Location { get; init; }
    public required PalletStatus Status { get; set; }
}
