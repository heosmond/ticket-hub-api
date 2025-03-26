using System.ComponentModel.DataAnnotations;

namespace ticket_hub_api
{
    public class Purchase
    {
        [Required]
        public int ConcertId { get; set; }


        [EmailAddress]
        [MaxLength(255)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;


        [RegularExpression(@"^[a-zA-Z'\s]{1,50}$", ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;


        [Phone]
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = string.Empty;


        [Range(1, 6, ErrorMessage = "Quantity must be between 1 and 6")]
        [Required]
        public int Quantity { get; set; }


        [CreditCard]
        [Required(ErrorMessage = "Credit card number is required")]
        public string CreditCard { get; set; } = string.Empty;


        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "Invalid expiration")]
        [Required(ErrorMessage = "Credit card expiration is required")]
        public string Expiration { get; set;} = string.Empty;


        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "Invalid security code")]
        [Required(ErrorMessage = "Credit card security code is required")]
        public string SecurityCode { get; set; } = string.Empty;


        [MaxLength(95)]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;


        [MaxLength(45)]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = string.Empty;


        [MaxLength(20)]
        [Required(ErrorMessage = "Province is required")]
        public string Province { get; set; } = string.Empty;


        [MaxLength(12)]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Invalid postal code format")]
        [Required(ErrorMessage = "Postal code is required")]
        public string PostalCode { get; set; } = string.Empty;

        [MaxLength(90)]
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = string.Empty;

    }
}
