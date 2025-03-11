using Trackify.Data.Type.Abs;
using Trackify.Data.Type.Enums;

namespace Trackify.Data.Type;
public class WarehouseLocation : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required string Code { get; set; }
    public required string Name { get; set; }

    /// <summary>
    /// KỆ
    /// </summary>
    public required int Rack { get; set; }

    /// <summary>
    /// DÃY
    /// </summary>
    public required int Row { get; set; }

    /// <summary>
    /// TẦNG
    /// </summary>
    public required int Shelf { get; set; }

    /// <summary>
    /// Ô CHỨA
    /// </summary>
    public required int Bin { get; set; }

    public required int? OrganizationId { get; init; }
    public Organization? Organization { get; init; }
    public required LocationStatus Status { get; set; }
}
