using Billing.API.Models;
using Billing.API.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.API.Services
{
    public interface ISalesService
    {
        //Customer
        Task<Customer> CreateCustomerAsync(CustomerCreateDto createCustomerDto);
        
        Customer GetCustomerById(int id);
        CustomerDetailsDto GetCustomerWithInvoicesDetails(Customer id);        
        IEnumerable<Customer> SearchCustomers(string crit);
        IEnumerable<Customer> GetCustomerList();

        Task<Customer> UpdateCustomer(Customer original, Customer changed);

        Task<bool> DeleteCustomerAsync(Customer id);

        //Invoice

        Task<Invoice> CreateInvoiceAsync(InvoiceCreateDto obj);
        
        IEnumerable<Invoice> GetAllInvoices();
        IEnumerable<Invoice> GetInvoicesWithCustomer();
        IEnumerable<Invoice> GetInvoicesWithCustomerName();
        Invoice GetInvoice(int id);

        Task<Invoice> UpdateInvoice(Invoice original, Invoice changed);

        Task DeleteInvoiceAsync(Invoice invoice);
    }
}