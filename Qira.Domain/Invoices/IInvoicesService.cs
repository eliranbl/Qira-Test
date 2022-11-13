using Qira.Common.Paging;

namespace Qira.Domain.Invoices;

/// <summary>
/// Invoices Service.
/// </summary>
public interface IInvoicesService
{
    /// <summary>
    /// Get invoice by identifier.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Invoice Response.</returns>
    public Task<InvoiceResponse?> GetByIdAsync(int id);

    /// <summary>
    /// Get invoices.   
    /// </summary>
    /// <param name="query">Invoice query.</param>
    /// <returns>Invoices response page list.</returns>
    public Task<Page<InvoiceResponse>> GetInvoicesAsync(InvoiceQuery query);

    /// <summary>
    /// Add new invoice.
    /// </summary>
    /// <param name="request">Add invoice request.</param>
    /// <returns>Identifier.</returns>
    public Task<int> AddInvoiceAsync(AddInvoiceRequest request);

    /// <summary>
    /// Update invoice.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <param name="request">Update invoice request.</param>
    /// <returns>Invoice.</returns>
    public Task<InvoiceResponse?> UpdateAsync(int id, UpdateInvoiceRequest request);
}