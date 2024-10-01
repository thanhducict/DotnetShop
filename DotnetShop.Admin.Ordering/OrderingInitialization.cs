using DotnetShop.Admin.Core.Initialization;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.FileProviders;

namespace DotnetShop.Admin.Ordering
{
    public class OrderingInitialization : IInitialization
    {
        public void ConfigureContainer(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ITagHelperComponent, OrderingTagHelperComponent>();
        }

        public void ConfigureUseStaticFilesMiddleware(WebApplication app)
        {
            var path = Path.Combine(app.Environment.ContentRootPath, @"modules/DotnetShop.Admin.Ordering");

            if(Directory.Exists(path))
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(path),
                    RequestPath = "/admin-ordering-assets"
                });
            }
        }
    }
}
