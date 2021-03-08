using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Models
{

    public class Customer
    {
        /// <summary>
        /// Gets or sets the customer id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets first name of the customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the customer
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        /// Gets or sets email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the customer picture url
        /// </summary>
        public string Url { get; set; } = string.Empty;

    }
}
