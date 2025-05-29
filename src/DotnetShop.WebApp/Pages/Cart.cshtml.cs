using DotnetShop.WebApp.Models.Cart;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace DotnetShop.WebApp.Pages
{
    [Authorize(Roles = "Customer")]
    public class CartModel(ICatalogService catalogService, ICartService cartService) : PageModel
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

            if (cart == null)
            {
                cart = new Cart
                {
                    Username = HttpContext.User.Identity.Name,
                    Items = []
                };
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

        //public IActionResult OnGetRemoveFromCart(int productId)
        //{
        //    _cartService.RemoveFromCart(productId);

        //    return RedirectToPage();
        //}

        //public IActionResult OnPostCheckout()
        //{
        //    var cartViewModel = GetCartViewModel();
        //    if (cartViewModel.CartLineItemViewModels.Count == 0)
        //    {
        //        return Page();
        //    }

        //    var customerId = _userManager.Users
        //        .Include(u => u.Customer)
        //        .FirstOrDefault(u => u.UserName.ToLower() == HttpContext.User.Identity.Name.ToLower())
        //        .Customer.CustomerId;

        //    _checkoutService.Checkout(customerId, cartViewModel);
        //    _cartService.ClearCart();

        //    return LocalRedirect("/CheckoutComplete");
        //}

        //private CartViewModel GetCartViewModel()
        //{
        //    var products = _productRepository.GetProducts();
        //    var cartItemViewModels = _cartService.GetCart().CartLineItems
        //        .Select(c =>
        //        {
        //            var model = new CartLineItemViewModel
        //            {
        //                ProductId = c.ProductId,
        //                ProductName = products.Where(p => p.ProductId == c.ProductId).SingleOrDefault().Name,
        //                ProductPrice = products.Where(p => p.ProductId == c.ProductId).SingleOrDefault().Price,
        //                CartLineItemQuantity = c.Quantity,
        //            };
        //            model.CartLineItemTotal = model.CartLineItemQuantity * model.ProductPrice;

        //            return model;
        //        })
        //        .ToList();

        //    return new CartViewModel
        //    {
        //        CartLineItemViewModels = cartItemViewModels,
        //        CartTotal = _cartService.GetCartTotal()
        //    };
        //}
    }
}
