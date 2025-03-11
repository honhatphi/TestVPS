namespace Trackify.Data.Type.Abs;
public abstract class Entity : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
}
