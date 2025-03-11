using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
public sealed class PalletContent : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();

    public required int PalletId { get; init; }
    public Pallet Pallet { get; init; } = null!;
    public required int ProductId { get; init; }
    public Product Product { get; init; } = null!;
    public required int InboundOrderId { get; init; }
    public InboundOrder InboundOrder { get; init; } = null!;
    public decimal Quantity { get; set; }
}
