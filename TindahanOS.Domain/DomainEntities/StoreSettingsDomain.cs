namespace TindahanOS.Domain.DomainEntities;

public class StoreSettingsDomain
{
    public Guid Id { get; set; }

    public Guid StoreId { get; set; }

    public string CurrencyCode { get; set; } = "PHP";

    public string TimeZoneId { get; set; } = "Asia/Manila";

    public bool AllowNegativeStock { get; set; } = false;

    public bool RequireGCashVerification { get; set; } = true;

    public int DefaultDebtDueDays { get; set; } = 0;

    public void SetCurrencyCode(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode)
            || currencyCode.Length != 3)
        {
            throw new ArgumentException(
                "Currency code must contain three characters.",
                nameof(currencyCode));
        }

        CurrencyCode = currencyCode.ToUpperInvariant();
    }

    public void SetDefaultDebtDueDays(int days)
    {
        if (days < 0 || days > 365)
        {
            throw new ArgumentOutOfRangeException(
                nameof(days),
                "Debt due days must be between 0 and 365.");
        }

        DefaultDebtDueDays = days;
    }
}