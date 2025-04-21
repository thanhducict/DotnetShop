using DotnetShop.Admin.UI.Areas.Admin.Models;

namespace DotnetShop.Admin.UI.Areas.Admin.Dtos
{
    public class GetCategoriesDto
    {
        public IEnumerable<CategoryModel> Categories { get; set; } = default!;
    }
}
