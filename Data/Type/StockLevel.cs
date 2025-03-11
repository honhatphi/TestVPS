using Trackify.Data.Type.Abs;

namespace Trackify.Data.Type;
/// <summary>
/// MỨC TỒN KHO
/// </summary>
public class StockLevel : IEntity
{
    public int Id { get; private set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public required int PeriodId { get; init; }
    public StockTakePeriod Period { get; init; } = null!;
    public required int ProductId { get; init; }
    public Product Product { get; init; } = null!;
    public required int ProjectId { get; init; }
    public PartnerProject Project { get; init; } = null!;

    /// <summary>
    /// MỨC TỒN ĐẦU KỲ
    /// </summary>
    public required decimal BeginningQuantity { get; set; }

    /// <summary>
    /// NHẬP
    /// </summary>
    public required decimal InboundQuantity { get; set; }

    /// <summary>
    /// NHẬP KHÁC
    /// </summary>
    public required decimal OtherInboundQuantity { get; set; }

    /// <summary>
    /// XUẤT
    /// </summary>
    public required decimal OutboundQuantity { get; set; }

    /// <summary>
    /// XUẤT KHÁC
    /// </summary>
    public required decimal OtherOutboundQuantity { get; set; }

    /// <summary>
    /// MỨC TỒN CUỐI KỲ
    /// </summary>
    public required decimal EndingQuantity { get; set; }
}
