using DotnetShop.Admin.UI.Models;

namespace DotnetShop.Admin.UI.Dtos
{
    public class GetProductsByCategoryDto
    {
        public IEnumerable<ProductModel> Products { get; set; } = default!;
    }
}
