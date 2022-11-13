using Microsoft.EntityFrameworkCore;
using Qira.Common.Paging;
using Qira.Domain.Invoices;
using System.Linq.Expressions;

namespace Qira.EF.Repositories;

/// <summary>
/// Invoices repository.
/// </summary>
public class InvoicesRepository : IInvoicesRepository
{
    private readonly QiraDbContext _dbContext;

    /// <summary>
    /// Create repository.
    /// </summary>
    /// <param name="dbContext">Data base Context.</param>
    public InvoicesRepository(QiraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get async.s
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Invoice.</returns>
    public async Task<Invoice?> GetAsync(int id)
    {
        return await _dbContext.Invoices.FindAsync(id); 
    }

    /// <summary>
    /// Get invoices.
    /// </summary>
    /// <param name="query">Invoice query.</param>
    /// <returns>Invoice page list.</returns>
    public async Task<Page<Invoice>> GetInvoicesAsync(InvoiceQuery query)
    {
        var queryable = _dbContext.Invoices.AsQueryable();
        queryable = Search(queryable, query);
        queryable = ApplySorting(queryable, query);

        var invoices = await queryable.ToPageAsync(query.PageNumber, query.PageSize);

        return invoices;
    }

    /// <summary>
    /// Add invoice.
    /// </summary>
    /// <param name="invoice">Invoice.</param>
    /// <returns>Identifier.</returns>
    public async Task<int> AddInvoiceAsync(Invoice invoice)
    {
        invoice.CreatedDateTime = DateTime.UtcNow;
        invoice.Amount = Math.Round(invoice.Amount, 2);

        await _dbContext.AddAsync(invoice);
        await _dbContext.SaveChangesAsync();

        return invoice.Id;
    }

    /// <summary>
    /// Update invoice.
    /// </summary>
    /// <param name="invoice">Invoice.</param>
    /// <returns>Invoice.</returns>
    public async Task<Invoice> UpdateInvoiceAsync(Invoice invoice)
    {
        invoice.ModifiedDataTime = DateTime.UtcNow;

        _dbContext.Update(invoice);
        await _dbContext.SaveChangesAsync();

        return invoice;
    }

    #region Private

    private static IQueryable<Invoice> Search(IQueryable<Invoice> invoices, InvoiceQuery query)
    {
        if (query.Amount is not null)
            invoices = invoices.Where(x => Equals(x.Amount, query.Amount));

        if (query.CreatedDateTime is not null)
            invoices = invoices.Where(x => x.CreatedDateTime == query.CreatedDateTime);

        if (query.ModifiedDataTime is not null)
            invoices = invoices.Where(x => x.ModifiedDataTime == query.ModifiedDataTime);

        if (query.PaymentMethod.HasValue)
            invoices = invoices.Where(x => x.PaymentMethod == query.PaymentMethod);

        if (query.ProcessingStatus.HasValue)
            invoices = invoices.Where(x => x.ProcessingStatus == query.ProcessingStatus);

        return invoices;
    }

    private IQueryable<Invoice> ApplySorting(IQueryable<Invoice> dbQuery, InvoiceQuery query)
    {
        var sorting = GetSorting(query.SortBy);
        dbQuery = !query.SortDesc ? dbQuery.OrderBy(sorting) : dbQuery.OrderByDescending(sorting);

        return dbQuery;
    }

    private Expression<Func<Invoice, object>> GetSorting(InvoiceQueryParameter parameter)
    {
        return parameter switch
        {
            InvoiceQueryParameter.Id => x => x.Id,
            InvoiceQueryParameter.Amount => x => x.Amount,
            InvoiceQueryParameter.ProcessingStatus => x => x.ProcessingStatus,
            InvoiceQueryParameter.PaymentMethod => x => x.PaymentMethod,
            InvoiceQueryParameter.CreatedDateTime => x => x.CreatedDateTime,
            InvoiceQueryParameter.ModifiedDataTime => x => x.ModifiedDataTime,
            _ => x => x.Id
        };
    }

    #endregion
}