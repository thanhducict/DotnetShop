using DotnetShop.Admin.Core.MenuProvider;

namespace DotnetShop.Admin.Dashboard
{
    public class DashboardMenuProvider : IAdminMenuProvider<AdminMenuItem>
    {
        public IEnumerable<AdminMenuItem> GetMenuItems()
        {
            return new List<AdminMenuItem>
            {
                new AdminMenuItem { AspPage = "Dashboard", AspPageHandler = string.Empty, MenuItemText = "Dashboard", Order = 10 }
            };
        }
    }
}
