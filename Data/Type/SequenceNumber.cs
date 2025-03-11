using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
public sealed class SequenceNumber : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required string Code { get; set; }
    public required int NextValue { get; set; }
}
