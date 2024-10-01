using Microsoft.AspNetCore.Builder;

namespace DotnetShop.Admin.Core.Initialization
{
    public interface IInitialization
    {
        void ConfigureContainer(WebApplicationBuilder builder);
        void ConfigureUseStaticFilesMiddleware(WebApplication app);
    }
}
