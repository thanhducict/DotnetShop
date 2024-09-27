using DotnetShop.Admin.Core.Initialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddRazorPages();

var allModules = AppDomain.CurrentDomain.GetAssemblies()
               .SelectMany(s => s.GetTypes()).Where(p => typeof(IInitialization).IsAssignableFrom(p) && p.IsClass);
foreach (var item in allModules)
{
    var module = Activator.CreateInstance(item) as IInitialization;
    if (module != null)
    {
        module.ConfigureContainer(builder);
    }
}

var app = builder.Build();

app.UseStaticFiles();

app.MapRazorPages();
app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Catalog}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Default Area",
    pattern: "{area=Admin}/{controller=Catalog}/{action=Index}/{id?}");

app.Run();
