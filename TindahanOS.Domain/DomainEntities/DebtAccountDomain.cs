using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class DebtAccountDomain
{
    public Guid Id { get; set; }

    public Guid StoreId { get; set; }

    public Guid CustomerId { get; set; }

    public DebtAccountStatus Status { get; set; } = DebtAccountStatus.Open;

    public string? Notes { get; set; }

    public void Close()
    {
        Status = DebtAccountStatus.Closed;
    }

    public void Reopen()
    {
        Status = DebtAccountStatus.Open;
    }
}