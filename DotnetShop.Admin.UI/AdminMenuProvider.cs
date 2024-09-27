using DotnetShop.Admin.Core.MenuProvider;

namespace DotnetShop.Admin.UI
{
    public class AdminMenuProvider : IAdminMenuProvider<AdminMenuItem>
    {
        public IEnumerable<AdminMenuItem> GetMenuItems()
        {
            return new List<AdminMenuItem>
            {
                new AdminMenuItem { AspArea = "Admin", AspController = "Catalog", AspAction = "Index", MenuItemText = "Catalog", Order = 1 },
            };
        }
    }
}
