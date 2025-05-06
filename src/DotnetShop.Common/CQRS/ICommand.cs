namespace DotnetShop.Common.CQRS
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
