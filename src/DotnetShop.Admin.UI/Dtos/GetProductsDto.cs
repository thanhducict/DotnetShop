using DotnetShop.Admin.UI.Models;

namespace DotnetShop.Admin.UI.Dtos
{
    public class GetProductsDto
    {
        public IEnumerable<ProductModel> Products { get; set; } = default!;
        public PagingInfoModel PagingInfo { get; set; } = default!;
    }
}
