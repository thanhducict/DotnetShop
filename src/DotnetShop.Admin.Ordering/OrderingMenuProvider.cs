using DotnetShop.Admin.Core.MenuProvider;

namespace DotnetShop.Admin.Ordering
{
    public class OrderingMenuProvider : IAdminMenuProvider<AdminMenuItem>
    {
        public IEnumerable<AdminMenuItem> GetMenuItems()
        {
            return new List<AdminMenuItem>
            {
                new AdminMenuItem { AspPage = "Ordering", AspPageHandler = string.Empty, MenuItemText = "Ordering", Order = 2 }
            };
        }
    }
}
