namespace DotnetShop.Admin.UI.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public Guid CategoryGuid { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
