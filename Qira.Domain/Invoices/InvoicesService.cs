using AutoMapper;
using Qira.Common.Paging;

namespace Qira.Domain.Invoices;

/// <summary>
/// Invoices service.
/// </summary>
public class InvoicesService : IInvoicesService
{
    private readonly IMapper _mapper;
    private readonly IInvoicesRepository _invoicesRepository;

    /// <summary>
    /// Create invoice service.
    /// </summary>
    /// <param name="mapper">Mapper.</param>
    /// <param name="invoicesRepository">Invoice repository.</param>
    public InvoicesService(IMapper mapper, IInvoicesRepository invoicesRepository)
    {
        _mapper = mapper;
        _invoicesRepository = invoicesRepository;
    }

    /// <summary>
    /// Get by identifier.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Invoice response.</returns>
    public async Task<InvoiceResponse?> GetByIdAsync(int id)
    {
        var invoice = await _invoicesRepository.GetAsync(id);

        return invoice is null ? null : _mapper.Map<InvoiceResponse>(invoice);
    }

    /// <summary>
    /// Get invoices.   
    /// </summary>
    /// <param name="query">Invoice query.</param>
    /// <returns>Invoices response page list.</returns>
    public async Task<Page<InvoiceResponse>> GetInvoicesAsync(InvoiceQuery query)
    {
        var invoices = await _invoicesRepository.GetInvoicesAsync(query);

        var invoicesResponse = _mapper.Map<Page<InvoiceResponse>>(invoices);

        return invoicesResponse;
    }

    /// <summary>
    /// Add new invoice.
    /// </summary>
    /// <param name="request">Add invoice request.</param>
    /// <returns>Identifier.</returns>
    public async Task<int> AddInvoiceAsync(AddInvoiceRequest request)
    {
        var map = _mapper.Map<Invoice>(request);

       return await  _invoicesRepository.AddInvoiceAsync(map);
    }

    /// <summary>
    /// Update invoice.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <param name="request">Update invoice request.</param>
    /// <returns>Invoice.</returns>
    public async Task<InvoiceResponse?> UpdateAsync(int id, UpdateInvoiceRequest request)
    {
        var invoiceEntry = await _invoicesRepository.GetAsync(id);

        if (invoiceEntry is null)
            return null;

        _mapper.Map(request, invoiceEntry);
        
        var  invoice =  await _invoicesRepository.UpdateInvoiceAsync(invoiceEntry);

        return _mapper.Map<InvoiceResponse>(invoice);
    }
}