namespace DotnetShop.Common.CQRS
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
