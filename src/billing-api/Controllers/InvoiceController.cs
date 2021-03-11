using Billing.API.Models;
using Billing.API.Models.Dtos;
using Billing.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Billing.API.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly ISalesService _salesService;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ISalesService salesService, ILogger<InvoiceController> logger)
        {
            _salesService = salesService;
            _logger = logger;
        }

        [HttpGet("getAll")]
        public IActionResult GetInvoices()
        {
            var invoices = _salesService.GetInvoicesWithCustomerName();
            if (invoices is null)
            {
                _logger.LogDebug("Invoices result is null");
                return NotFound();
            }
            return Ok(invoices);
        }

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceCreateDto obj)
        {
            var customer = _salesService.GetCustomerById(obj.CustomerId);
            if (customer is null)
            {
                return BadRequest("Customer not exists");
            }
            try
            {
                Invoice invoice = await _salesService.CreateInvoiceAsync(obj);
                
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't add invoice to database");
                return BadRequest("Failed to add invoice to database");
            }

        }

        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            Invoice invoice = _salesService.GetInvoice(id);
            if (invoice is null)
            {
                return NotFound("Invoice not exists");
            }
            await _salesService.DeleteInvoiceAsync(invoice);

            return Ok(_salesService.GetAllInvoices());
        }

    }
}
