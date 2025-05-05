using DotnetShop.ShoppingCart.API.Carts.CheckoutCart;
using DotnetShop.ShoppingCart.API.Carts.DeleteCart;
using DotnetShop.ShoppingCart.API.Carts.GetCartByUsername;
using DotnetShop.ShoppingCart.API.Carts.GetCarts;
using DotnetShop.ShoppingCart.API.Carts.StoreCart;

namespace DotnetShop.ShoppingCart.API.Carts
{
    [ApiController]
    [Route("{controller}")]
    public class CartsController(IRequestDispatcher dispatcher) : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCartsResponse>> GetCarts([FromQuery] GetCartsRequest request)
        {
            var result = await dispatcher.DispatchAsync(new GetCartsQuery(request.PageNumber, request.PageSize));

            return new GetCartsResponse(result.Carts);
        }

        [Route("{action}/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCartByUsernameResponse>> GetCartByUsername([FromRoute] string username)
        {
            var result = await dispatcher.DispatchAsync(new GetCartByUsernameQuery(username));

            return new GetCartByUsernameResponse(result.Cart);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StoreCartResponse>> StoreCart([FromBody] StoreCartRequest request)
        {
            var result = await dispatcher.DispatchAsync(new StoreCartCommand(request.Cart));

            return new StoreCartResponse(result.Username);
        }

        [HttpPost]
        [Route("{action}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CheckoutCartResponse>> Checkout([FromBody] CheckoutCartRequest request)
        {
            var result = await dispatcher.DispatchAsync(new CheckoutCartCommand(request.CartCheckoutDto));

            return new CheckoutCartResponse(result.IsSuccess);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DeleteCartResponse>> DeleteCart([FromBody] DeleteCartRequest request)
        {
            var result = await dispatcher.DispatchAsync(new DeleteCartCommand(request.Username));

            return new DeleteCartResponse(result.IsSuccess);
        }
    }
}
