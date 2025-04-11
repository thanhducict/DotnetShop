using DotnetShop.Admin.Core.Initialization;
using DotnetShop.Admin.Dashboard;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.FileProviders;

namespace DotnetShop.Admin.Dashboard
{
    public class DashboardInitialization : IInitialization
    {
        public void ConfigureContainer(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ITagHelperComponent, DashboardTagHelperComponent>();
        }

        public void ConfigureUseStaticFilesMiddleware(WebApplication app)
        {
            var path = Path.Combine(app.Environment.ContentRootPath, @"modules/DotnetShop.Admin.Dashboard");

            if (Directory.Exists(path))
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(path),
                    RequestPath = "/admin-dashboard-assets"
                });
            }
        }
    }
}
