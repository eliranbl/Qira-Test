using System.ComponentModel.DataAnnotations;
using Qira.Domain.PaymentMethods;

namespace Qira.Domain.Invoices;

/// <summary>
/// Add Invoice request.
/// </summary>
public class AddInvoiceRequest
{
    /// <summary>
    /// Identifier.
    /// </summary>
    [Required(ErrorMessage = "Invoice identifier is required!")]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    /// <summary>
    /// Amount.
    /// </summary>
    [Required(ErrorMessage = "Amount is required!")]
    [Range(1, double.MaxValue)]
    public double Amount { get; set; }

    /// <summary>
    /// Payment Method.
    /// </summary>
    [Required(ErrorMessage = "Payment method is required!")]
    public PaymentMethod PaymentMethod { get; set; }
}