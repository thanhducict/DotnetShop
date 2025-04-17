namespace DotnetShop.Admin.UI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public Guid CategoryGuid { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class GetCategoriesResponse
    {
        public IEnumerable<CategoryModel> Categories { get; set; } = default!;
    }
}
