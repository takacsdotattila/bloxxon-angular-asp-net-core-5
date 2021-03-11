using System.ComponentModel.DataAnnotations;

namespace Billing.API.Models.Dtos
{
    /// <summary>
    /// Dto for create new customer
    /// </summary>
    public class CustomerCreateDto
    {
        /// <summary>
        /// Gets or sets first name of the customer
        /// </summary>
        [MaxLength(80)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the customer
        /// </summary>
        [MaxLength(80)]
        public string LastName { get; set; }


        /// <summary>
        /// Gets or sets email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the customer picture url
        /// </summary>
        public string ImgUrl { get; set; } = string.Empty;
    }
}
