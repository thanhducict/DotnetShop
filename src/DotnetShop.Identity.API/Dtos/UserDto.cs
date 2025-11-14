using DotnetShop.Identity.API.Models;

namespace DotnetShop.Identity.API.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public Address? ShippingAddress { get; set; }
        public Address? BillingAddress { get; set; }
        public Payment? Payment { get; set; }
    }
}
