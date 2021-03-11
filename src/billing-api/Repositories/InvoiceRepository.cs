using Billing.API.Data;
using Billing.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Billing.API.Repositories
{
    public class InvoiceRepository : GenericSalesRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(SalesContext context) : base(context)
        {
        }

        public IEnumerable<Invoice> GetInvoicesByCustomerId(int id)
        {
            return _table.Where(x => x.CustomerId.Equals(id)).ToList();
        }

        public IEnumerable<Invoice> GetInvoicesWithCustomer()
        {
            return _table.Include(x => x.Customer).ToList();
        }

        public Invoice GetInvoiceWithCustomerById(int id)
        {
            return _table.FirstOrDefault(x => x.Id.Equals(id));
        }

        public bool HasCustomerAnyInvoice(int id)
        {
            return _table.Any(x => x.CustomerId.Equals(id));
        }
    }
}