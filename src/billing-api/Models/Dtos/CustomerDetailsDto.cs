using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Models.Dtos
{
    /// <summary>
    /// Dto for CustomerDeatils view
    /// </summary>
    public class CustomerDetailsDto
    {
        /// <summary>
        /// Get or sets Customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or Sets Invoices
        /// </summary>
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();

    }
}
