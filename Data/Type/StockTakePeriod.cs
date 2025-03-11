using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
/// <summary>
/// KÌ KIỂM KÊ
/// </summary>
public class StockTakePeriod : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required int OrganizationId { get; init; }
    public Organization Organization { get; init; } = null!;
    public required string Code { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required bool IsClosed { get; set; }
}
