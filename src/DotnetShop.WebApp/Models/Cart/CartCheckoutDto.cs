namespace DotnetShop.WebApp.Models.Cart
{
    public class CartCheckoutDto
    {
        public Customer Customer { get; set; }
        public List<CartItem> CartItems { get; set; } = default!;
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public Payment Payment { get; set; }
        public decimal TotalPrice { get; set; } = default!;
    }

    public class Customer
    {
        public Guid CustomerGuid { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class Address
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string AddressLine { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string State { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
    }

    public class Payment
    {
        public string CardName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public string Expiration { get; set; } = default!;
        public string CVV { get; set; } = default!;
        public int PaymentMethod { get; set; } = default!;
    }
}
