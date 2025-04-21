using DotnetShop.Admin.UI.Areas.Admin.Models;

namespace DotnetShop.Admin.UI.Areas.Admin.Dtos
{
    public class GetProductsByCategoryDto
    {
        public IEnumerable<ProductModel> Products { get; set; } = default!;
    }
}
