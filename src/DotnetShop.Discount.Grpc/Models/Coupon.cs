namespace DotnetShop.Discount.Grpc.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public Guid ProductGuid { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Amount { get; set; }
    }
}
