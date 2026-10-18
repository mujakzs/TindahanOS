using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public static class GCashTransactionMapping
{
    public static GCashTransactionDomain ToDomain(
        this GCashTransaction transaction)
    {
        return new GCashTransactionDomain
        {
            Id = transaction.Id,
            StoreId = transaction.StoreId,

            TransactionType = Enum.IsDefined(
                typeof(GCashTransactionType),
                transaction.TransactionType)
                ? (GCashTransactionType)transaction.TransactionType
                : throw new InvalidOperationException(
                    $"Invalid GCash transaction type: {transaction.TransactionType}"),

            CustomerName = transaction.CustomerName,
            PhoneNumber = transaction.PhoneNumber,
            Amount = transaction.Amount,
            ReferenceNumber = transaction.ReferenceNumber,

            Status = Enum.IsDefined(
                typeof(GCashTransactionStatus),
                transaction.Status)
                ? (GCashTransactionStatus)transaction.Status
                : throw new InvalidOperationException(
                    $"Invalid GCash transaction status: {transaction.Status}"),

            Notes = transaction.Notes,
            TransactionDate = transaction.TransactionDate
        };
    }

    public static GCashTransaction ToEntity(
        this GCashTransactionDomain domain)
    {
        return new GCashTransaction
        {
            Id = domain.Id,
            StoreId = domain.StoreId,
            TransactionType = (int)domain.TransactionType,
            CustomerName = domain.CustomerName,
            PhoneNumber = domain.PhoneNumber,
            Amount = domain.Amount,
            ReferenceNumber = domain.ReferenceNumber,
            Status = (int)domain.Status,
            Notes = domain.Notes,
            TransactionDate = domain.TransactionDate
        };
    }
}