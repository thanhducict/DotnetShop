using DotnetShop.Admin.Core.MenuProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DotnetShop.Admin.UI.Pages.Shared.Components.AdminNavigation
{
    public class AdminNavigation : ViewComponent
    {
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "AdminNavigation";

        public AdminNavigation(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IViewComponentResult Invoke()
        {
            if (!_memoryCache.TryGetValue(CacheKey, out List<AdminMenuItem> adminMenuItems))
            {
                adminMenuItems = new List<AdminMenuItem>();

                var allMenuProviders = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes()).Where(p => typeof(IAdminMenuProvider<AdminMenuItem>).IsAssignableFrom(p) && p.IsClass);

                foreach (var item in allMenuProviders)
                {
                    var menuProvider = Activator.CreateInstance(item) as IAdminMenuProvider<AdminMenuItem>;
                    if (menuProvider != null && menuProvider.GetMenuItems() != null && menuProvider.GetMenuItems().Any())
                    {
                        var menuItems = menuProvider.GetMenuItems();

                        adminMenuItems.AddRange(menuItems);
                    }
                }

                adminMenuItems = adminMenuItems.OrderBy(x => x.Order).ToList();
                _memoryCache.Set(CacheKey, adminMenuItems);
            }

            var model = new AdminNavigationViewModel
            {
                AdminMenuItems = adminMenuItems
            };

            return View(adminMenuItems);
        }
    }
}
