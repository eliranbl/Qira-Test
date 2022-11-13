using Qira.Domain.PaymentMethods;
using Qira.Domain.ProcessingStatuses;

namespace Qira.Domain.Invoices;

/// <summary>
/// Invoice query.
/// </summary>
public class InvoiceQuery
{
    /// <summary>
    /// Page size.
    /// </summary>
    private readonly int _pageSize = 10;

    /// <summary>
    /// Max page size.
    /// </summary>
    const int MaxPageSize = 100;

    /// <summary>
    /// Amount.
    /// </summary>
    public double? Amount { get; set; }

    /// <summary>
    /// Processing status.
    /// </summary>
    public ProcessingStatus? ProcessingStatus { get; set; }

    /// <summary>
    /// Payment Method.
    /// </summary>
    public PaymentMethod? PaymentMethod { get; set; }

    /// <summary>
    /// Created date time.
    /// </summary>
    public DateTime? CreatedDateTime { get; set; }

    /// <summary>
    /// Modified data time.
    /// </summary>
    public DateTime? ModifiedDataTime { get; set; }

    /// <summary>
    /// Sort by parameter.
    /// </summary>
    public InvoiceQueryParameter SortBy { get; set; }

    /// <summary>
    /// Is sort descending.
    /// </summary>
    public bool SortDesc { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    /// <summary>
    /// Page number.
    /// </summary>
    public int PageNumber { get; set; } = 1;
}