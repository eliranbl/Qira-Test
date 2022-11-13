using Qira.Domain.PaymentMethods;
using Qira.Domain.ProcessingStatuses;

namespace Qira.Domain.Invoices;

/// <summary>
/// Invoice response
/// </summary>
public class InvoiceResponse
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Amount.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Processing status.
    /// </summary>
    public ProcessingStatus ProcessingStatus { get; set; }

    /// <summary>
    /// Payment Method.
    /// </summary>
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// Created date time.
    /// </summary>
    public DateTime CreatedDateTime { get; set; }

    /// <summary>
    /// Modified data time.
    /// </summary>
    public DateTime ModifiedDataTime { get; set; }
}