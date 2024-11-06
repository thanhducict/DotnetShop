using DotnetShop.Common.Exceptions;

namespace DotnetShop.Catalog.API.Exceptions
{
    internal class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid id) : base("Product", id)
        {
        }
    }
}
