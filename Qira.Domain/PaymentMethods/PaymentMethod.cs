namespace Qira.Domain.PaymentMethods;

/// <summary>
/// Payment Method.
/// </summary>
public enum PaymentMethod
{
    /// <summary>
    /// Credit card.
    /// </summary>
    CreditCard = 1,

    /// <summary>
    /// Debit card.
    /// </summary>
    DebitCard = 2,

    /// <summary>
    /// Electronic check.
    /// </summary>
    ElectronicCheck = 3
}