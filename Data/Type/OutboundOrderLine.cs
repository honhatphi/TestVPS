using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
public sealed class OutboundOrderLine : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();

    public required int OutboundOrderId { get; init; }
    public OutboundOrder OutboundOrder { get; init; } = null!;
    public required int ProductId { get; init; }
    public Product Product { get; init; } = null!;
    public required decimal Quantity { get; set; }
}
