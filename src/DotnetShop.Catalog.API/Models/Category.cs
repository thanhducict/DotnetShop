namespace DotnetShop.Catalog.API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public Guid CategoryGuid { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
