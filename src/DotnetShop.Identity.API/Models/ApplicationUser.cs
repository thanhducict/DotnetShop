using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DotnetShop.Identity.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public bool Gender { get; set; }

        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
