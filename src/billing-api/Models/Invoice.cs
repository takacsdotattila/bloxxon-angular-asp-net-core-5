using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.API.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }

        public int Amount { get; set; }
        public DateTime DeadLine { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }


    }
}
