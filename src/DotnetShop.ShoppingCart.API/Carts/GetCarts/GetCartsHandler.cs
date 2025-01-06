using DotnetShop.ShoppingCart.API.Repositories;

namespace DotnetShop.ShoppingCart.API.Carts.GetCarts
{
    public class GetCartsQuery(int PageNumber = 1, int PageSize = 10) : IQuery<GetCartsResult>
    {
        public int PageNumber { get; set; } = PageNumber;
        public int PageSize { get; set; } = PageSize;
    }

    public class GetCartsResult(IEnumerable<Cart> carts)
    {
        public IEnumerable<Cart> Carts { get; } = carts;
    }

    internal class GetCartsQueryHandler(ICartRepository cartRepository, ILogger<GetCartsQueryHandler> logger)
        : IQueryHandler<GetCartsQuery, GetCartsResult>
    {
        public async Task<GetCartsResult> Handle(GetCartsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetCartsQueryHandler.Handle called with {@Query}", query);
            var carts = await cartRepository.GetCarts(cancellationToken);

            return new GetCartsResult(carts);
        }
    }
}
