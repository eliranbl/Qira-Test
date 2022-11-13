using Qira.Common.Paging;

namespace Qira.Domain.Invoices;

/// <summary>
/// Invoices repository.
/// </summary>
public interface IInvoicesRepository
{
    /// <summary>
    /// Get invoice.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Invoice.</returns>
    public Task<Invoice?> GetAsync(int id);

    /// <summary>
    /// Get invoices.
    /// </summary>
    /// <param name="query">Invoice query.</param>
    /// <returns>Paged List invoices.</returns>
    public Task<Page<Invoice>> GetInvoicesAsync(InvoiceQuery query);

    /// <summary>
    /// Add invoice.
    /// </summary>
    /// <param name="invoice">Invoice.</param>
    /// <returns>Identifier.</returns>
    public Task<int> AddInvoiceAsync(Invoice invoice);

    /// <summary>
    /// Update invoice.
    /// </summary>
    /// <param name="invoice">Invoice.</param>
    /// <returns>Invoice.</returns>
    public Task<Invoice> UpdateInvoiceAsync(Invoice invoice);
}