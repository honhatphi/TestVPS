namespace Trackify.Data.Type.Abs;
public abstract class OwnedEntity : Entity, IOwnedEntity
{
    public int UserId { get; init; }
    public User User { get; init; } = null!;
}
