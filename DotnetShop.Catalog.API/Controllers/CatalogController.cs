using DotnetShop.Catalog.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetShop.Catalog.API.Controllers
{
    [ApiController]
    [EnableCors("Policy1")]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogDbContext _catalogDbContext;

        public CatalogController(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            return await _catalogDbContext.Products.Select(x => new ProductDTO
            {
                ProductId = x.ProductId,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            }).ToListAsync();
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<ProductDTO?> GetById(string productId)
        {
            var result = await _catalogDbContext.Products.FindAsync(productId);
            if(result != null)
            {
                return new ProductDTO
                {
                    ProductId = result.ProductId,
                    Name = result.Name,
                    ImageUrl = result.ImageUrl,
                    Price = result.Price
                };
            }
            else
            {
                return new ProductDTO();
            }
        }
    }
}
