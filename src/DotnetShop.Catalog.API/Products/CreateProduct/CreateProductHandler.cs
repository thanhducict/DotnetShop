using MediatR;

namespace DotnetShop.Catalog.API.Products.CreateProduct
{
    public class CreateProductCommand() : IRequest<CreateProductResult>;

    public class CreateProductResult(Guid id);

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
