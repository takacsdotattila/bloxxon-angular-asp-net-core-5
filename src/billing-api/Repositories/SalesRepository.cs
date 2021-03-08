using Billing.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Repositories
{
    internal class SalesRepository : IUnitOfWorkSales
    {
        private readonly IGenericRepository<Customer> _customerRepo;

        public SalesRepository(IGenericRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            return _customerRepo.GetAll().ToList();
        }
    }
}
