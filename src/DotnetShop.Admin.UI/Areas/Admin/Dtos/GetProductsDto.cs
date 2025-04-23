using DotnetShop.Admin.UI.Areas.Admin.Models;

namespace DotnetShop.Admin.UI.Areas.Admin.Dtos
{
    public class GetProductsDto
    {
        public IEnumerable<ProductModel> Products { get; set; } = default!;
        public PagingInfoModel PagingInfo { get; set; } = default!;
    }
}
