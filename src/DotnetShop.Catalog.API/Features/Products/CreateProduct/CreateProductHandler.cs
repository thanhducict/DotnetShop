using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Products.CreateProduct
{
    public record CreateProductCommand(Guid ProductGuid, string ProducName, string ShortDescription, string LongDescription,
        List<string> ImageUrls, string ImageThumbnailUrl, decimal Price, int CategoryId) : ICommand<CreateProductResult>;

    public record CreateProductResult(int ProductId);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProducName).NotEmpty().WithMessage("ProductName is required");
            RuleFor(x => x.ProductGuid).NotEmpty().WithMessage("ProductGuid is required");
            RuleFor(x => x.ImageUrls).NotNull().WithMessage("ImageUrls is required");
            RuleFor(x => x.ImageThumbnailUrl).NotEmpty().WithMessage("ImageThumbnailUrl is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required");
        }
    }

    internal class CreateProductCommandHandler(IProductRepository productRepository, ILogger<CreateProductCommandHandler> logger)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("CreateProductCommandHandler.Handle called with {@Query}", command);
            var product = new Product
            {
                ProductGuid = command.ProductGuid,
                ProductName = command.ProducName,
                ShortDescription = command.ShortDescription,
                LongDescription = command.LongDescription,
                ImageUrls = command.ImageUrls,
                ImageThumbnailUrl = command.ImageThumbnailUrl,
                Price = command.Price,
                CategoryId = command.CategoryId,
            };

            var productId = await productRepository.CreateProduct(product, cancellationToken);

            return new CreateProductResult(productId);
        }
    }
}
