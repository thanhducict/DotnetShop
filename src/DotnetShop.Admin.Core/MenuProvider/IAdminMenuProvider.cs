namespace DotnetShop.Admin.Core.MenuProvider
{
    public interface IAdminMenuProvider<T>
    {
        /// <summary>
        /// Provides the menu items of the navigation.
        /// </summary>
        /// <returns>
        /// A list of <see cref="T"/>s that the provider exposes.
        /// </returns>
        public IEnumerable<T> GetMenuItems();
    }
}
