namespace DotnetShop.Catalog.API.Infrastructure
{
    public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
    {
    }
}
