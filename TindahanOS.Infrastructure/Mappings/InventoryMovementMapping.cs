using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public static class InventoryMovementMapping
{
    public static InventoryMovementDomain ToDomain(
        this InventoryMovement movement)
    {
        return new InventoryMovementDomain
        {
            Id = movement.Id,
            StoreId = movement.StoreId,
            ProductId = movement.ProductId,

            MovementType = Enum.IsDefined(
                typeof(InventoryMovementType),
                movement.MovementType)
                ? (InventoryMovementType)movement.MovementType
                : throw new InvalidOperationException(
                    $"Invalid inventory movement type: {movement.MovementType}"),

            Quantity = movement.Quantity,
            ReferenceNumber = movement.ReferenceNumber,
            Notes = movement.Notes,
            MovementDate = movement.MovementDate
        };
    }

    public static InventoryMovement ToEntity(
        this InventoryMovementDomain domain)
    {
        return new InventoryMovement
        {
            Id = domain.Id,
            StoreId = domain.StoreId,
            ProductId = domain.ProductId,
            MovementType = (int)domain.MovementType,
            Quantity = domain.Quantity,
            ReferenceNumber = domain.ReferenceNumber,
            Notes = domain.Notes,
            MovementDate = domain.MovementDate
        };
    }
}