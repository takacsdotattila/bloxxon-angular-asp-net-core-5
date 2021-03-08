using Billing.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Controllers
{
    [ApiController]
    [Route("api/invoices")]
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
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _salesService.GetAllInvoices();
            if(invoices is null)
            {
                _logger.LogDebug("Invoices result is null");
                return NotFound();
            }
            return Ok(invoices);
        }
    }
}
