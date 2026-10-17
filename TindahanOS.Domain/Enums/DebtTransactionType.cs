namespace TindahanOS.Domain.Enums;

public enum DebtTransactionType
{
    Charge = 1,                 // adds to the customer's debt
    Repayment = 2,             // reduces the customer's debt.
    AdjustmentIncrease = 3,   // increase debt to correct a document discrepancy
    AdjustmentDecrease = 4   // decreases debt to correct a documented discrepancy.
}