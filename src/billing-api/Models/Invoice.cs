using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.API.Models
{
    public class Invoice
    {
        /// <summary>
        /// Gets or sets Invoice Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Customer Id
        /// </summary>
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Amount of the invoice
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the deadline
        /// </summary>
        public DateTime DeadLine { get; set; }

        /// <summary>
        /// Gets or sets the Customer
        /// </summary>
        /// <remarks>Navigation property</remarks>
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }


    }
}
