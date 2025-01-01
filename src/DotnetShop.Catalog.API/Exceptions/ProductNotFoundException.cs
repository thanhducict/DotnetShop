using DotnetShop.Common.Exceptions;

namespace DotnetShop.Catalog.API.Exceptions
{
    internal class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) : base("Product", id)
        {
        }
    }
}
