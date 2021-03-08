using Billing.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.API.Services
{
    public interface ISalesService
    {
        Task<List<Customer>> GetAllCustomer();
        Task<List<CustomerListItemDto>> SearchCustomers(string crit);
        Task<List<CustomerListItemDto>> GetCustomerList();
        Task<List<Invoice>> GetAllInvoices();
        Task<Customer> GetCustomerById(string id);
    }
}