using DotnetShop.ShoppingCart.API.Carts.GetCart;

namespace DotnetShop.ShoppingCart.API.Carts
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController(IMediator mediator) : ControllerBase
    {
        [Route("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCartResponse>> GetCart([FromRoute] string username)
        {
            var result = await mediator.Send(new GetCartQuery());

            return new GetCartResponse(result.Carts);
        }
    }
}
