using DotnetShop.Admin.UI.Areas.Admin.Models;

namespace DotnetShop.Admin.UI.Areas.Admin.Dtos
{
    public class GetProductByIdDto
    {
        public ProductModel Product { get; set; } = default!;
    }
}
