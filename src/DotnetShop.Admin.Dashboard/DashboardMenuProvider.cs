using DotnetShop.Admin.Core.MenuProvider;

namespace DotnetShop.Admin.Dashboard
{
    public class DashboardMenuProvider : IAdminMenuProvider<AdminMenuItem>
    {
        public IEnumerable<AdminMenuItem> GetMenuItems()
        {
            return new List<AdminMenuItem>
            {
                new AdminMenuItem { AspArea = "Admin", AspController = "Dashboard", AspAction = "Index", MenuItemText = "Dashboard", Order = 10 }
            };
        }
    }
}
