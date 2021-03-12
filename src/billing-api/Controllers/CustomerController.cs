using Billing.API.Models;
using Billing.API.Models.Dtos;
using Billing.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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

        [HttpGet("getAll")]
        public IActionResult GetCustomerList()
        {
            var result = _salesSerivce.GetCustomerList();
            if (result is null)
            {
                _logger.LogWarning("Customer list is null");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("search")]
        public IActionResult GetCustomers(string crit = null)
        {            
            var result = _salesSerivce.SearchCustomers(crit);
            if (result is null)
            {
                _logger.LogWarning("Customer list is null");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("addCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerCreateDto customerDto)
        {
            Customer customer = null;
            try
            {
                customer = await _salesSerivce.CreateCustomerAsync(customerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't add customer to database");
                return BadRequest("Failed to add customer to database");

            }

            return Ok(customer);
        }

        [HttpGet("getById")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _salesSerivce.GetCustomerById(id);
            if (customer is null)
            {
                _logger.LogWarning("Customer is null");
                return NotFound();
            }
            
            return Ok(customer);
        }

        [HttpGet("getCustomerDetails")]
        public IActionResult GetCustomerDetails(int id)
        {
            var customer = _salesSerivce.GetCustomerById(id);
            if (customer is null)
            {
                _logger.LogWarning("Customer is null");
                return NotFound();
            }
            var result = _salesSerivce.GetCustomerWithInvoicesDetails(customer);
            return Ok(result);
        }


        [HttpPut("updateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            var originalCustomer = _salesSerivce.GetCustomerById(customer.Id);
            if (originalCustomer is null)
            {
                return NotFound("Customer not exists");
            }
            //get customer by id...
            Customer updatedCustomer = await _salesSerivce.UpdateCustomer(originalCustomer, customer);
            //update
            //return customer
            return Ok(updatedCustomer);
        }

        [HttpDelete]
        [Route("deleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            _logger.LogDebug("Deleting customer with id: {{{0}}}", id);
            Customer customer = _salesSerivce.GetCustomerById(id);

            if (customer is null)
            {
                _logger.LogDebug("Customer with id: {{{0}}} not exists", id);
                return NotFound();
            }

            try
            {
                var succeeded = await _salesSerivce.DeleteCustomerAsync(customer);
                if (succeeded)
                {
                    _logger.LogDebug("Deletion of customer was successful. id: {{{0}}}", id);
                    return Ok();
                }
                return BadRequest("Unable to delete");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during delete a customer");
                throw;
            }
        }
    }
}
