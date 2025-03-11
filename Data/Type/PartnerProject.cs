using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
/// <summary>
/// DỰ ÁN
/// </summary>
public sealed class PartnerProject : IEntity, IOwnedEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required int UserId { get; init; }
    public User User { get; init; } = null!;

    public required string Code { get; set; }
    public required string Name { get; set; }
}
