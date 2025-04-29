using DotnetShop.Admin.UI.Models;

namespace DotnetShop.Admin.UI.Dtos
{
    public class GetProductByIdDto
    {
        public ProductModel Product { get; set; } = default!;
    }
}
