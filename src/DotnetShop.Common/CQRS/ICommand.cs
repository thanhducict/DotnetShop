using MediatR;

namespace DotnetShop.Common
{
    public interface ICommand : ICommand<Unit>
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
