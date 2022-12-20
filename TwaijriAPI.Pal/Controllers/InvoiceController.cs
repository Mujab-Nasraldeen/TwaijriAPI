using Microsoft.AspNetCore.Mvc;
using TwaijriAPI.Bal.Dtos;
using TwaijriAPI.Bal.Services;
using TwaijriAPI.Pal.Contracts;

namespace TwaijriAPI.Pal.Controllers;
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet(ApiRoute.Invoice.GetAllInvoices)]
    public async Task<IActionResult> GetAllInvoices()
    {
        try
        {
            var invoices = await _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoute.Invoice.GetPaidInvoices)]
    public async Task<IActionResult> GetPaidInvoices()
    {
        try
        {
            var invoices = _invoiceService.GetPaidInvoices();
            return Ok(invoices);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoute.Invoice.GetNotPaidInvoices)]
    public async Task<IActionResult> GetNotPaidInvoices()
    {
        try
        {
            var invoices = _invoiceService.GetNotPaidInvoices();
            return Ok(invoices);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoute.Invoice.GetInvoiceById)]
    public async Task<IActionResult> GetInvoiceById(Guid id)
    {
        try
        {
            var invoice = await _invoiceService.GetInvoiceById(id);
            return Ok(invoice);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(ApiRoute.Invoice.AddInvoice)]
    public async Task<IActionResult> AddInvoice([FromBody] AddInvoiceRequestDto req)
    {
        try
        {
            var invoice = await _invoiceService.AddInvoice(req);
            return Ok(invoice);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut(ApiRoute.Invoice.UpdateInvoice)]
    public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceRequestDto req)
    {
        try
        {
            var invoice = await _invoiceService.UpdateInvoice(req);
            return Ok(invoice);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete(ApiRoute.Invoice.DeleteInvoice)]
    public async Task<IActionResult> DeleteInvoice(Guid id)
    {
        try
        {
            var invoice = await _invoiceService.DeleteInvoice(id);
            return Ok(invoice);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
