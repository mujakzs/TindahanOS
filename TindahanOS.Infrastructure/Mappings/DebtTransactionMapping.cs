using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities.Debts;

namespace TindahanOS.Infrastructure.Mappings;

public static class DebtTransactionMapping
{
    public static DebtTransactionDomain ToDomain(
        this DebtTransaction transaction)
    {
        return new DebtTransactionDomain
        {
            Id = transaction.Id,
            DebtAccountId = transaction.DebtAccountId,

            Type = Enum.IsDefined(
                typeof(DebtTransactionType),
                transaction.Type)
                ? (DebtTransactionType)transaction.Type
                : throw new InvalidOperationException(
                    $"Invalid debt transaction type: {transaction.Type}"),

            Amount = transaction.Amount,
            TransactionDate = transaction.TransactionDate,
            ReferenceNumber = transaction.ReferenceNumber,
            Notes = transaction.Notes
        };
    }

    public static DebtTransaction ToEntity(
        this DebtTransactionDomain domain)
    {
        return new DebtTransaction
        {
            Id = domain.Id,
            DebtAccountId = domain.DebtAccountId,
            Type = (int)domain.Type,
            Amount = domain.Amount,
            TransactionDate = domain.TransactionDate,
            ReferenceNumber = domain.ReferenceNumber,
            Notes = domain.Notes
        };
    }
}