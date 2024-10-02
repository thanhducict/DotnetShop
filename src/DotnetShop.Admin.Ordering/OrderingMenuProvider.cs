using DotnetShop.Admin.Core.MenuProvider;

namespace DotnetShop.Admin.Ordering
{
    public class OrderingMenuProvider : IAdminMenuProvider<AdminMenuItem>
    {
        public IEnumerable<AdminMenuItem> GetMenuItems()
        {
            return new List<AdminMenuItem>
            {
                new AdminMenuItem { AspArea = "Admin", AspController = "Ordering", AspAction = "Index", MenuItemText = "Ordering", Order = 2 }
            };
        }
    }
}
