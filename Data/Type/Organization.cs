using Trackify.Data.Type.Abs;
using Trackify.Data.Type.Enums;

namespace Trackify.Data.Type;
public sealed class Organization : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();

    public required string Code { get; set; }
    public required string Name { get; set; }
    public required OrganizationType Type { get; set; }
    public required string TaxCode { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Notes { get; set; }
}
