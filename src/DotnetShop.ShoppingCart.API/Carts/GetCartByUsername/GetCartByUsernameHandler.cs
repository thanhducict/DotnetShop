namespace DotnetShop.ShoppingCart.API.Carts.GetCartByUsername
{
    public class GetCartByUsernameQuery(string username) : ICommand<GetCartByUsernameResult>
    {
        public string Username { get; } = username;
    }

    public class GetCartByUsernameResult(Cart cart)
    {
        public Cart Cart { get; set; } = cart;
    }

    public class GetCartByUsernameQueryHandler : IRequestHandler<GetCartByUsernameQuery, GetCartByUsernameResult>
    {
        public async Task<GetCartByUsernameResult> Handle(GetCartByUsernameQuery request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { }, cancellationToken);
            return new GetCartByUsernameResult(new Cart("fake"));
        }
    }
}
