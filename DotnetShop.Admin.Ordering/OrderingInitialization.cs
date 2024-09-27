using DotnetShop.Admin.Core.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DotnetShop.Admin.Ordering
{
    public class OrderingInitialization : IInitialization
    {
        public void ConfigureContainer(WebApplicationBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var part = new AssemblyPart(assembly);
            builder.Services.AddControllersWithViews()
                .ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(part));
        }
    }
}
