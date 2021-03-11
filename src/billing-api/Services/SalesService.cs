using AutoMapper;
using Billing.API.Models;
using Billing.API.Models.Dtos;
using Billing.API.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Services
{
    internal class SalesService : ISalesService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<SalesService> _logger;
        ICustomerRepository _customerRepo;
        IInvoiceRepository _invoiceRepo;

        public SalesService(ICustomerRepository customerRepo,
                            IInvoiceRepository invoiceRepo,
                            IMapper mapper,
                            ILogger<SalesService> logger)//IDistributedCache cache, )
        {
            _customerRepo = customerRepo;
            _invoiceRepo = invoiceRepo;
            _mapper = mapper;
            _logger = logger;
            //_cache = cache;
        }

        #region Customer

        // C
        public async Task<Customer> CreateCustomerAsync(CustomerCreateDto createCustomerDto)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerDto);
            _customerRepo.Insert(customer);
            await _customerRepo.Save();
            return customer;
        }

        //R
        public IEnumerable<Customer> GetCustomerList()
        {
            return _customerRepo.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepo.GetById(id);
        }

        /// <summary>
        /// Search for customers by email, first name, last name
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Customers based on criteria</returns>
        public IEnumerable<Customer> SearchCustomers(string searchText)
        {
            var result = _customerRepo
                .SearchCustomers(x => x.Email.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase) ||
                                 x.FirstName.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase) ||
                                 x.LastName.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase));

            return result;
        }

        public CustomerDetailsDto GetCustomerWithInvoicesDetails(Customer customer)
        {
            var invoices = _invoiceRepo.GetInvoicesByCustomerId(customer.Id);
            var result = new CustomerDetailsDto()
            {
                Customer = customer,
            };
            if (invoices != null)
            {
                result.Invoices = invoices.ToList();
            }
            return result;
        }

        //U
        public async Task<Customer> UpdateCustomer(Customer original, Customer changed)
        {
            original.FirstName = changed.FirstName;
            original.LastName = changed.LastName;
            original.Email = changed.Email;
            original.ImgUrl = changed.ImgUrl;
            _customerRepo.Update(original);
            await _customerRepo.Save();
            return _customerRepo.GetById(original.Id);
        }

        //D
        public async Task<bool> DeleteCustomerAsync(Customer customer)
        {
            if (_invoiceRepo.HasCustomerAnyInvoice(customer.Id))
            {
                _logger.LogDebug("Customer has invoice, deletion not possible. id: {{{0}}}", customer.Id);
                return false;
            }
            _customerRepo.Delete(customer);
            await _customerRepo.Save();
            return true;
        }

        #endregion

        #region Invoices

        //C
        public async Task<Invoice> CreateInvoiceAsync(InvoiceCreateDto obj)
        {
            var invoice = _mapper.Map<Invoice>(obj);
            _invoiceRepo.Insert(invoice);
            await _invoiceRepo.Save();
            return _invoiceRepo.GetInvoiceWithCustomerById(invoice.Id);

        }

        //R
        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _invoiceRepo.GetAll();
        }
        public IEnumerable<Invoice> GetInvoicesWithCustomer()
        {
            return _invoiceRepo.GetInvoicesWithCustomer();
        }
        public IEnumerable<Invoice> GetInvoicesWithCustomerName()
        {
            return _invoiceRepo.GetInvoicesWithCustomer();
        }

        public Invoice GetInvoice(int id)
        {
            return _invoiceRepo.GetById(id);
        }

        //U
        public async Task<Invoice> UpdateInvoice(Invoice original, Invoice changed)
        {
            original.Amount = changed.Amount;
            original.CustomerId = changed.CustomerId;
            original.DeadLine = changed.DeadLine;
            _invoiceRepo.Update(original);
            await _invoiceRepo.Save();
            return _invoiceRepo.GetById(original.Id);
        }

        //D
        public async Task DeleteInvoiceAsync(Invoice invoice)
        {
            _invoiceRepo.Delete(invoice);
            await _invoiceRepo.Save();
        }        

        #endregion
    }
}