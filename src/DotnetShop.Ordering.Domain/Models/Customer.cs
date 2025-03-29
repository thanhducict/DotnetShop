namespace DotnetShop.Ordering.Domain.Models
{
    public class Customer : Entity<CustomerId>
    {
        public string Username { get; private set; } = default!;
        public string Email { get; private set; } = default!;

        public static Customer Create(CustomerId customerId, string username, string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);

            var customer = new Customer()
            {
                Id = customerId,
                Username = username,
                Email = email,
            };

            return customer;
        }
    }
}
