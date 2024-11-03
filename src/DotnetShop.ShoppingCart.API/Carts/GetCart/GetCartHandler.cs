using DotnetShop.Common.CQRS;

namespace DotnetShop.ShoppingCart.API.Carts.GetCart
{
    public class GetCartQuery : IQuery<GetCartResult>
    {
    }

    public class GetCartResult(IEnumerable<Cart> carts)
    {
        public IEnumerable<Cart> Carts { get; set; } = carts;
    }

    public class GetCartQueryHandler : IQueryHandler<GetCartQuery, GetCartResult>
    {
        public async Task<GetCartResult> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { }, cancellationToken);
            return new GetCartResult(new List<Cart>());
        }
    }
}
