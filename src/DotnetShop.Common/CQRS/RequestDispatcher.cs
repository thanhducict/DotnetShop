using DotnetShop.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetShop.Common.CQRS
{
    public class RequestDispatcher(IServiceProvider provider) : IRequestDispatcher
    {
        public async Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request) where TResponse : notnull
        {
            var requestType = request.GetType();
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
            var handler = provider.GetRequiredService(handlerType);

            // Resolve all applicable behaviors
            var behaviorType = typeof(IPipelineBehavior<,>).MakeGenericType(requestType, typeof(TResponse));
            var behaviors = provider.GetServices(behaviorType)
                .Cast<dynamic>()
                .Reverse()
                .ToList();

            // Final handler function
            Func<Task<TResponse>> handlerFunc = () => (Task<TResponse>)handler.GetType()
               .GetMethod("Handle")
               ?.Invoke(handler, new object[] { request, CancellationToken.None })!;

            // Wrap handler with behaviors
            foreach (var behavior in behaviors)
            {
                var next = handlerFunc;
                handlerFunc = () => behavior.Handle((dynamic)request, next, CancellationToken.None);
            }

            return await handlerFunc();
        }
    }
}
