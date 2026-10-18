using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public static class CustomerMapping
{
    public static CustomerDomain ToDomain(this Customer customer)
    {
        return new CustomerDomain
        {
            Id = customer.Id,
            StoreId = customer.StoreId,
            FullName = customer.FullName,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            Notes = customer.Notes,

            Status = Enum.IsDefined(
                typeof(CustomerStatus),
                customer.Status)
                ? (CustomerStatus)customer.Status
                : throw new InvalidOperationException(
                    $"Invalid customer status value: {customer.Status}")
        };
    }

    public static Customer ToEntity(this CustomerDomain domain)
    {
        return new Customer
        {
            Id = domain.Id,
            StoreId = domain.StoreId,
            FullName = domain.FullName,
            PhoneNumber = domain.PhoneNumber,
            Address = domain.Address,
            Notes = domain.Notes,
            Status = (int)domain.Status
        };
    }
}