using DotnetShop.Admin.Core.MenuProvider;

namespace DotnetShop.Admin.UI.Areas.Admin.Views.Shared.Components.AdminNavigation
{
    public class AdminNavigationViewModel
    {
        public IEnumerable<AdminMenuItem> AdminMenuItems { get; set; }
    }
}
