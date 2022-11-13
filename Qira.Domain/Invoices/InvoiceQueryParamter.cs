namespace Qira.Domain.Invoices;

/// <summary>
/// Invoice query parameter.
/// </summary>
public enum InvoiceQueryParameter
{
    /// <summary>
    /// Identifier.
    /// </summary>
    Id = 1,

    /// <summary>
    /// Amount.
    /// </summary>
    Amount = 2,

    /// <summary>
    /// Processing status.
    /// </summary>
    ProcessingStatus = 3,

    /// <summary>
    /// Payment Method.
    /// </summary>
    PaymentMethod = 4,

    /// <summary>
    /// Created date time.
    /// </summary>
    CreatedDateTime = 5,

    /// <summary>
    /// Modified data time.
    /// </summary>
    ModifiedDataTime = 6
}