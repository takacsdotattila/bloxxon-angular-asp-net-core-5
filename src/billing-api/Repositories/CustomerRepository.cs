using Billing.API.Data;
using Billing.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Billing.API.Repositories
{
    class CustomerRepository : GenericSalesRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesContext context) : base(context)
        {

        }

        public IEnumerable<Customer> SearchCustomers(Func<Customer, bool> crit)
        {
            return _table.Where(crit).ToList();
        }
    }
}
