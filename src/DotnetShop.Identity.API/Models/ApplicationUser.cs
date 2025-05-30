using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DotnetShop.Identity.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;

        public bool Gender { get; set; }

        public Address? ShippingAddress { get; set; } = default!;
        public Address? BillingAddress { get; set; } = default!;
        public Payment? Payment { get; set; } = default!;
    }
}
