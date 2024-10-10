using MediatR;

namespace DotnetShop.Common
{
    public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
    {
    }
}
