using TindahanOS.Domain.DomainEntities;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public static class StoreSettingsMapping
{
    public static StoreSettingsDomain ToDomain(
        this StoreSetting settings)
    {
        return new StoreSettingsDomain
        {
            Id = settings.Id,
            StoreId = settings.StoreId,
            CurrencyCode = settings.CurrencyCode,
            TimeZoneId = settings.TimeZoneId,
            AllowNegativeStock = settings.AllowNegativeStock,
            RequireGCashVerification = settings.RequireGCashVerification,
            DefaultDebtDueDays = settings.DefaultDebtDueDays
        };
    }

    public static StoreSetting ToEntity(
        this StoreSettingsDomain domain)
    {
        return new StoreSetting
        {
            Id = domain.Id,
            StoreId = domain.StoreId,
            CurrencyCode = domain.CurrencyCode,
            TimeZoneId = domain.TimeZoneId,
            AllowNegativeStock = domain.AllowNegativeStock,
            RequireGCashVerification = domain.RequireGCashVerification,
            DefaultDebtDueDays = domain.DefaultDebtDueDays
        };
    }
}