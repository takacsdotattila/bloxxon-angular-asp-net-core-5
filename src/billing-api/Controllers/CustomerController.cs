using Billing.API.Models;
using Billing.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISalesService _salesSerivce;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ISalesService salesSerivce, ILogger<CustomerController> logger)
        {
            _salesSerivce = salesSerivce;
            _logger = logger;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _salesSerivce.GetCustomerList();
            if(result is null)
            {
                _logger.LogWarning("Customer list is null");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _salesSerivce.GetCustomerById(id);
            if (result is null)
            {
                _logger.LogWarning("Customer is null");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetCustomers(string crit)
        {
            var result = await _salesSerivce.SearchCustomers(crit);
            if (result is null)
            {
                _logger.LogWarning("Customer list is null");
                return NotFound();
            }
            return Ok(result);
        }
    }
}
