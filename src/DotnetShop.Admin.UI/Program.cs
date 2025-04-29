using DotnetShop.Admin.Core.HttpClient;
using DotnetShop.Admin.Core.Initialization;
using DotnetShop.Admin.UI;
using DotnetShop.Admin.UI.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var services = builder.Services;

services.AddRazorPages();
services.AddAuthentication(Constants.MyBearerScheme).AddCookie(Constants.MyBearerScheme, options =>
{
    options.LoginPath = "/AppAuthentication/Login";
    options.AccessDeniedPath = "/AppAuthentication/NoPermission";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
});

var allModuleTypes = AppDomain.CurrentDomain.GetAssemblies()
               .SelectMany(s => s.GetTypes()).Where(p => typeof(IInitialization).IsAssignableFrom(p) && p.IsClass);

var allModules = new List<IInitialization>();

foreach (var item in allModuleTypes)
{
    var module = Activator.CreateInstance(item) as IInitialization;
    if (module != null)
    {
        allModules.Add(module);
    }
}

foreach (var module in allModules)
{
    module.ConfigureContainer(builder);
}

services.AddHttpClient();
services.AddScoped<IHttpClientFactoryBase, HttpClientFactoryBase>();
services.AddScoped<IAppAuthenticationService, AppAuthenticationService>();
services.AddScoped<ICatalogService, CatalogService>();

var app = builder.Build();

app.UseStaticFiles();
if (environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(environment.ContentRootPath, @"../DotnetShop.Admin.Ordering/ClientApp/dist")),
        RequestPath = "/admin-ordering-assets"
    });
}

foreach (var module in allModules)
{
    module.ConfigureUseStaticFilesMiddleware(app);
}

app.MapRazorPages();
app.MapGet("/", context =>
{
    context.Response.Redirect("/Catalog/List");
    return Task.CompletedTask;
});

app.MapRazorPages();
app.Run();
