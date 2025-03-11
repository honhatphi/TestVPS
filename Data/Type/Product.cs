using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
public class Product : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Barcode { get; set; }
    public string? Description { get; set; }
}
