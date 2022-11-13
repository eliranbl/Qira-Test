using Microsoft.AspNetCore.Mvc;
using Qira.Domain.Invoices;
using Qira.Domain.PaymentMethods;
using Qira.Domain.ProcessingStatuses;

namespace Qira.WebApi.Controllers;

/// <summary>
/// Invoices controller.
/// </summary>
[ApiController]
[Route("v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class InvoicesController : ControllerBase
{
    private readonly IInvoicesService _invoicesService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="invoicesService"></param>
    public InvoicesController(IInvoicesService invoicesService)
    {
        _invoicesService = invoicesService;
    }

    /// <summary>
    /// Get by identifier sync.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Invoice response.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(InvoiceResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            var result = await _invoicesService.GetByIdAsync(id);

            if (result == null)
                return NotFound($"Item {id} not found");

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    /// <summary>
    /// Get filtered invoices async.
    /// </summary>
    /// <param name="query">Invoice query.</param>
    /// <returns>Invoice response.</returns>
    [HttpGet("GetQuery")]
    [ProducesResponseType(typeof(InvoiceResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetQueryAsync([FromQuery] InvoiceQuery query)
    {
        try
        {
            var result = await _invoicesService.GetInvoicesAsync(query);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    /// <summary>
    /// Add new invoice.
    /// </summary>
    /// <param name="request">Add invoice request.</param>
    /// <returns>Identifier.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAsync([FromBody] AddInvoiceRequest request)
    {
        try
        {
            var invoiceExist = await _invoicesService.GetByIdAsync(request.Id);

            if (invoiceExist is not null)
                return BadRequest("Item already exist");

            var id = await _invoicesService.AddInvoiceAsync(request);

            return Ok(id);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    /// <summary>
    /// Update invoice async.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <param name="request">Update invoice request.</param>
    /// <returns>Invoice response.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(InvoiceResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateInvoiceRequest request)
    {
        try
        {
            if (!Enum.IsDefined(typeof(ProcessingStatus), request.ProcessingStatus))
                return BadRequest("Processing status is not valid.");

            if (!Enum.IsDefined(typeof(PaymentMethod), request.PaymentMethod))
                return BadRequest("Payment method is not valid.");

            var response = await _invoicesService.UpdateAsync(id, request);

            if (response is null)
                return NotFound($"Item {id} not found");

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }
}