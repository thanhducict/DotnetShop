using DotnetShop.ShoppingCart.API.Repositories;

namespace DotnetShop.ShoppingCart.API.Carts.GetCartByUsername
{
    public class GetCartByUsernameQuery(string username) : IQuery<GetCartByUsernameResult>
    {
        public string Username { get; } = username;
    }

    public class GetCartByUsernameResult(Cart cart)
    {
        public Cart Cart { get; set; } = cart;
    }

    public class GetCartByUsernameQueryHandler(ICartRepository cartRepository) : IRequestHandler<GetCartByUsernameQuery, GetCartByUsernameResult>
    {
        public async Task<GetCartByUsernameResult> Handle(GetCartByUsernameQuery query, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetCartByUsername(query.Username, cancellationToken);
            return new GetCartByUsernameResult(cart);
        }
    }
}
