using System;
using System.ComponentModel.DataAnnotations;

namespace Billing.API.Models.Dtos
{
    /// <summary>
    /// Dto for create new incoice
    /// </summary>
    public class InvoiceCreateDto
    {
        /// <summary>
        /// Gets or sets customer id
        /// </summary>
        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets amount
        /// </summary>
        [Range(1,int.MaxValue)]
        public int Amount { get; set; }        

        /// <summary>
        /// Gets or sets deadline
        /// </summary>
        public DateTime DeadLine { get; set; }
    }
}
