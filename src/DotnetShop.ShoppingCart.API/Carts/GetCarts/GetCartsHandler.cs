namespace DotnetShop.ShoppingCart.API.Carts.GetCarts
{
    public class GetCartsQuery : ICommand<GetCartsResult>
    {
    }

    public class GetCartsResult(IEnumerable<Cart> carts)
    {
        public IEnumerable<Cart> Carts { get; set; } = carts;
    }

    public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, GetCartsResult>
    {
        public async Task<GetCartsResult> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { }, cancellationToken);
            return new GetCartsResult(new List<Cart>());
        }
    }
}
