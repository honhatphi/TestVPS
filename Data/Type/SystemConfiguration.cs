using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
public sealed class SystemConfiguration : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required string Key { get; set; }
    public required string Value { get; set; }
    public string? Description { get; set; }
}
