namespace DotnetShop.Catalog.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories(CancellationToken cancellationToken);
        Task<Guid?> CreateCategory(Category category, CancellationToken cancellationToken);
    }
}
