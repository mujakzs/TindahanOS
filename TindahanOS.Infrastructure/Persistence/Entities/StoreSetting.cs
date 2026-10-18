namespace TindahanOS.Infrastructure.Persistence.Entities;

public class StoreSetting : BaseAuditEntity
{
    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public string CurrencyCode { get; set; } = "PHP";

    public string TimeZoneId { get; set; } = "Asia/Manila";

    public bool AllowNegativeStock { get; set; } = false;

    public bool RequireGCashVerification { get; set; } = true;

    public int DefaultDebtDueDays { get; set; } = 0;
}