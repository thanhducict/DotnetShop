using DotnetShop.Admin.UI.Models;

namespace DotnetShop.Admin.UI.Dtos
{
    public class GetCategoriesDto
    {
        public IEnumerable<CategoryModel> Categories { get; set; } = default!;
    }
}
