using DotnetShop.Common.Behaviors;
using DotnetShop.Common.CQRS;
using DotnetShop.Common.Exceptions.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace DotnetShop.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddScoped<IRequestDispatcher, RequestDispatcher>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddExceptionHandler<CustomExceptionHandler>();

            // Register all classes implementing IQuery
            //var queryTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => p.IsClass && !p.IsAbstract && p.GetInterfaces()
            //    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQuery<>)));

            //foreach (var queryType in queryTypes)
            //{
            //    foreach (var interfaceType in queryType.GetInterfaces()
            //        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQuery<>)))
            //    {
            //        services.AddSingleton(interfaceType, queryType);
            //    }
            //}

            var queryHandlerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass && !p.IsAbstract && p.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

            foreach (var queryHandlerType in queryHandlerTypes)
            {
                foreach (var interfaceType in queryHandlerType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                {
                    services.AddScoped(interfaceType, queryHandlerType);
                }
            }

            // Register all classes implementing IQueryHandler
            //var queryHandlerTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => p.IsClass && !p.IsAbstract && p.GetInterfaces()
            //    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)));

            //foreach (var queryHandlerType in queryHandlerTypes)
            //{
            //    foreach (var interfaceType in queryHandlerType.GetInterfaces()
            //        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
            //    {
            //        services.AddSingleton(interfaceType, queryHandlerType);
            //    }
            //}

            // Register all classes implementing ICommand
            //var commandTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => p.IsClass && !p.IsAbstract && p.GetInterfaces()
            //    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommand<>)));

            //foreach (var commandType in commandTypes)
            //{
            //    foreach (var interfaceType in commandType.GetInterfaces()
            //        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommand<>)))
            //    {
            //        services.AddSingleton(interfaceType, commandType);
            //    }
            //}

            // Register all classes implementing ICommandHandler
            ////var commandHandlerTypes = AppDomain.CurrentDomain.GetAssemblies()
            ////    .SelectMany(s => s.GetTypes())
            ////    .Where(p => p.IsClass && !p.IsAbstract && p.GetInterfaces()
            ////    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>)));

            ////foreach (var commandHandlerType in commandHandlerTypes)
            ////{
            ////    foreach (var interfaceType in commandHandlerType.GetInterfaces()
            ////       .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>)))
            ////    {
            ////        services.AddSingleton(interfaceType, commandHandlerType);
            ////    }
            ////}

            return services;
        }
    }
}
