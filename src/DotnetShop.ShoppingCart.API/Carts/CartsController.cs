using DotnetShop.ShoppingCart.API.Carts.DeleteCart;
using DotnetShop.ShoppingCart.API.Carts.GetCartByUsername;
using DotnetShop.ShoppingCart.API.Carts.GetCarts;
using DotnetShop.ShoppingCart.API.Carts.StoreCart;

namespace DotnetShop.ShoppingCart.API.Carts
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController(IMediator mediator) : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCartsResponse>> GetCarts()
        {
            var result = await mediator.Send(new GetCartsQuery());

            return new GetCartsResponse(result.Carts);
        }

        [Route("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCartByUsernameResponse>> GetCartByUsername([FromRoute] string username)
        {
            var result = await mediator.Send(new GetCartByUsernameQuery(username));
            return new GetCartByUsernameResponse(result.Cart);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StoreCartResponse>> StoreCart([FromBody] StoreCartRequest request)
        {
            var result = await mediator.Send(new StoreCartCommand(request.Cart));
            return new StoreCartResponse(result.IsSuccess);
        }

        [HttpDelete]
        [Route("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DeleteCartResponse>> DeleteCart([FromRoute] string username)
        {
            var result = await mediator.Send(new DeleteCartCommand(username));
            return new DeleteCartResponse(result.IsSuccess);
        }
    }
}
