using DotnetShop.WebApp.Models.Cart;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace DotnetShop.WebApp.Pages
{
    [Authorize(Roles = "Customer")]
    public class CartModel(ICatalogService catalogService, ICartService cartService, IIdentityService identityService) : PageModel
    {
        public Cart CartViewModel { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var result = await cartService.GetCartByUsername(HttpContext.User.Identity.Name, cancellationToken);

            CartViewModel = result.Cart ?? new Cart();
        }

        public async Task<IActionResult> OnPostAddToCart(int productId, int quantity, CancellationToken cancellationToken)
        {
            var getProductResponse = await catalogService.GetProductById(productId, cancellationToken);
            var selectedProduct = getProductResponse.Product;

            var cartResponse = await cartService.GetCartByUsername(HttpContext.User.Identity.Name, cancellationToken);
            var cart = cartResponse.Cart;

            if (string.IsNullOrEmpty(cart.Username))
            {
                cart = new Cart
                {
                    Username = HttpContext.User.Identity.Name,
                    Items = [new CartItem
                    {
                        ProductGuid = selectedProduct.ProductGuid,
                        ProductName = selectedProduct.ProductName,
                        Price = selectedProduct.Price,
                        Quantity = quantity
                    }],
                };

                await cartService.StoreCart(cart, cancellationToken);
            }
            else
            {
                var cartItem = cart.Items.SingleOrDefault(c => c.ProductGuid == selectedProduct.ProductGuid);
                if (cartItem == null)
                {
                    cartItem = new CartItem
                    {
                        ProductGuid = selectedProduct.ProductGuid,
                        ProductName = selectedProduct.ProductName,
                        Price = selectedProduct.Price,
                        Quantity = quantity
                    };
                    cart.Items.Add(cartItem);
                }
                else
                {
                    cartItem.Quantity += quantity;
                }

                await cartService.StoreCart(cart, cancellationToken);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromCart(CancellationToken cancellationToken)
        {
            await cartService.RemoveFromCart(HttpContext.User.Identity.Name, cancellationToken);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCheckout(CancellationToken cancellationToken)
        {
            var result = await cartService.GetCartByUsername(HttpContext.User.Identity.Name, cancellationToken);
            var customer = await identityService.GetProfileAsync(HttpContext.User.Identity.Name, cancellationToken);

            var cartCheckoutDto = new CartCheckoutDto
            {
                Customer = new Customer
                {
                    CustomerGuid = new Guid(customer.Id),
                    Email = customer.Email,
                    Username = customer.UserName,
                },
                CartItems = result.Cart?.Items ?? new List<CartItem>(),
                ShippingAddress = new Address
                {
                    FirstName = customer.ShippingAddress?.FirstName ?? "",
                    LastName = customer.ShippingAddress?.LastName ?? "",
                    EmailAddress = customer.Email,
                    AddressLine = customer.ShippingAddress?.AddressLine ?? "",
                    Country = customer.ShippingAddress?.Country ?? "",
                    State = customer.ShippingAddress?.State ?? "",
                    ZipCode = customer.ShippingAddress?.ZipCode ?? ""
                },
                BillingAddress = new Address
                {
                    FirstName = customer.ShippingAddress?.FirstName ?? "",
                    LastName = customer.ShippingAddress?.LastName ?? "",
                    EmailAddress = customer.Email,
                    AddressLine = customer.ShippingAddress?.AddressLine ?? "",
                    Country = customer.ShippingAddress?.Country ?? "",
                    State = customer.ShippingAddress?.State ?? "",
                    ZipCode = customer.ShippingAddress?.ZipCode ?? ""
                },
                Payment = new Payment
                {
                    CardName = customer.Payment?.CardName ?? "",
                    CardNumber = customer.Payment?.CardNumber ?? "",
                    Expiration = customer.Payment?.Expiration ?? "",
                    CVV = customer.Payment?.CVV ?? "",
                    PaymentMethod = customer.Payment?.PaymentMethod ?? 0,
                },
                TotalPrice = result.Cart?.Items.Sum(i => i.Price * i.Quantity) ?? 0
            };
            await cartService.Checkout(cartCheckoutDto, cancellationToken);

            return LocalRedirect("/ShoppingCart/CheckoutComplete");
        }
    }
}
