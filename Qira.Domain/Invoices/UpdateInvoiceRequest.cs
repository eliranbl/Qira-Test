using System.ComponentModel.DataAnnotations;
using Qira.Domain.PaymentMethods;
using Qira.Domain.ProcessingStatuses;

namespace Qira.Domain.Invoices;

/// <summary>
/// Update invoice Request.
/// </summary>
public class UpdateInvoiceRequest
{
    /// <summary>
    /// Amount.
    /// </summary>
    [Required(ErrorMessage = "Amount can't be null")]
    [Range(1, double.MaxValue)]
    public double Amount { get; set; }

    /// <summary>
    /// Processing status.
    /// </summary>
    [Required(ErrorMessage = "Processing status can't be null")]
    public ProcessingStatus ProcessingStatus { get; set; }

    /// <summary>
    /// Payment Method.
    /// </summary>
    [Required(ErrorMessage = "Payment method can't be null")]
    public PaymentMethod PaymentMethod { get; set; }
}