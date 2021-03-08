using AutoMapper;
using Billing.API.Models;
using Billing.API.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Billing.API.Services
{
    internal class SalesService : ISalesService
    {
        private readonly DistributedCacheEntryOptions _cacheOpts = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
        
        private readonly IUnitOfWorkSales _customerServiceRepository;
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;

        public SalesService(IUnitOfWorkSales customerServiceRepository, IDistributedCache cache, IMapper mapper)
        {
            _customerServiceRepository = customerServiceRepository;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            var result = await _customerServiceRepository.GetAllCustomer();
            return result;
        }

        public async Task<List<CustomerListItemDto>> SearchCustomers(string crit) 
        {
            List<Customer> customers = await _customerServiceRepository.GetAllCustomer();
            var filtered = customers.Where(x => x.Email.StartsWith(crit, StringComparison.InvariantCultureIgnoreCase) ||
                                                x.FirstName.StartsWith(crit, StringComparison.InvariantCultureIgnoreCase) ||
                                                x.LastName.StartsWith(crit, StringComparison.InvariantCultureIgnoreCase))
                                     .ToList();
            return _mapper.Map<List<CustomerListItemDto>>(filtered);
        }

        public async Task<List<CustomerListItemDto>> GetCustomerList()
        {
            List<Customer> customers = await _customerServiceRepository.GetAllCustomer();
            return  _mapper.Map<List<CustomerListItemDto>>(customers);
            
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
