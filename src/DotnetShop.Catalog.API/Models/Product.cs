namespace DotnetShop.Catalog.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public Guid ProductGuid { get; set; }
        public string ProductName { get; set; } = default!;
        public string ShortDescription { get; set; } = default!;
        public string LongDescription { get; set; } = default!;
        public List<string> ImageUrls { get; set; } = default!;
        public string ImageThumbnailUrl { get; set; } = default!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
