using Billing.API.Data;
using Billing.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Repositories
{
    class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly SalesContext _context;

        public CustomerRepository(SalesContext salesContext)
        {
            _context = salesContext;
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer obj)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
