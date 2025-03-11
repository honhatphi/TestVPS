using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
public sealed class User : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string DisplayName { get; set; }
    public required int OrganizationId { get; init; }
    public Organization Organization { get; init; } = null!;
    public required bool IsAdmin { get; set; }
    public required bool IsLocked { get; set; }
}
