using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Products.DeleteProduct
{
    public record DeleteProductCommand(int ProductId) : ICommand<DeleteProductResult>;

    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required");
        }
    }

    internal class DeleteProductCommandHandler(IProductRepository productRepository, ILogger<DeleteProductCommandHandler> logger)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Query}", command);

            var result = await productRepository.DeleteProduct(command.ProductId, cancellationToken);

            return new DeleteProductResult(result);
        }
    }
}
