using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
public class InboundOrderLine : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();

    public required int InboundOrderId { get; init; }
    public InboundOrder InboundOrder { get; init; } = null!;

    public required int ProductId { get; init; }
    public Product Product { get; init; } = null!;

    public required int PalletId { get; init; }
    public Pallet Pallet { get; init; } = null!;

    public required decimal Quantity { get; set; }
}
