using Billing.API.Models;
using System.Collections.Generic;

namespace Billing.API.Repositories
{
    interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        bool HasCustomerAnyInvoice(int id);

        IEnumerable<Invoice> GetInvoicesWithCustomer();

        IEnumerable<Invoice> GetInvoicesByCustomerId(int id);
        Invoice GetInvoiceWithCustomerById(int id);
    }
}
