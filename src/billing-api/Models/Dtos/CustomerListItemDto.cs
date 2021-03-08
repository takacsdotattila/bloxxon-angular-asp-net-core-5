using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Models
{

    public class CustomerListItemDto
    {
        /// <summary>
        /// Gets or sets the customer id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets first name of the customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the customer
        /// </summary>
        public string LastName { get; set; }
    }
}
