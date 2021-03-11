using Billing.API.Models;
using System;
using System.Collections.Generic;

namespace Billing.API.Repositories
{
    interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> SearchCustomers(Func<Customer, bool> func);
    }
}
