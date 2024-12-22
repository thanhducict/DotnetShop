using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Products.UpdateProduct
{
    public record UpdateProductCommand(int ProductId, Guid ProductGuid, string ProductName, string ShortDescription, string LongDescription,
        List<string> ImageUrls, string ImageThumbnailUrl, decimal Price, int CategoryId) : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty().WithMessage("Product ID is required");

            RuleFor(command => command.ProductName)
                .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

            RuleFor(command => command.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    internal class UpdateProductCommandHandler(IProductRepository productRepository, ILogger<UpdateProductCommandHandler> logger)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Query}", command);

            var product = new Product
            {
                ProductId = command.ProductId,
                ProductGuid = command.ProductGuid,
                ProductName = command.ProductName,
                ShortDescription = command.ShortDescription,
                LongDescription = command.LongDescription,
                ImageUrls = command.ImageUrls,
                ImageThumbnailUrl = command.ImageThumbnailUrl,
                Price = command.Price,
                CategoryId = command.CategoryId
            };

            var result = await productRepository.UpdateProduct(product, cancellationToken);

            return new UpdateProductResult(result);
        }
    }
}
