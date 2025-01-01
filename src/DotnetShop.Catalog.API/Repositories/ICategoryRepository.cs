namespace DotnetShop.Catalog.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<bool> CreateCategory(Category category);
    }
}
