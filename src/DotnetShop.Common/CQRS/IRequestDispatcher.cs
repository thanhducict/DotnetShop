namespace DotnetShop.Common.CQRS
{
    public interface IRequestDispatcher
    {
        Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request);
    }
}
