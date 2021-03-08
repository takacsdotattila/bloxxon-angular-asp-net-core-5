using Billing.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.API.Repositories
{
    internal interface IUnitOfWorkSales
    {
        Task<List<Customer>> GetAllCustomer();
    }
}