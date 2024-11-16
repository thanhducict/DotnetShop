namespace DotnetShop.Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public List<string> Categories { get; set; } = [];
        public string ShortDescription { get; set; } = default!;
        public string LongDescription { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string ImageThumbnailUrl { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
