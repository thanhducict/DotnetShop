using DotnetShop.Admin.Core.Initialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var services = builder.Services;

services.AddMvc();
services.AddRazorPages();
services.AddAuthentication("MyBearerScheme").AddJwtBearer("MyBearerScheme", options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtTokenSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtTokenSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["JwtTokenSettings:Secret"])),
        ClockSkew = TimeSpan.Zero
    };
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

app.MapControllerRoute(
    name: "Default Area",
    pattern: "{area=Admin}/{controller=Catalog}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
