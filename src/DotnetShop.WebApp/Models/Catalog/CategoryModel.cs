namespace DotnetShop.WebApp.Models.Catalog
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public Guid CategoryGuid { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public record GetCategoriesResponse(IEnumerable<CategoryModel> Categories);
}
