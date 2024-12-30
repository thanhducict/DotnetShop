using Microsoft.Data.SqlClient;
using System.Data;

namespace DotnetShop.Catalog.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CatalogDb")!;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            string sql = "SELECT * FROM Category";
            SqlDataReader dr;
            List<Category> categories = [];

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand cmd = new SqlCommand(sql, connection);
            dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                categories.Add(new Category
                {
                    CategoryId = dr.GetFieldValue<Guid>(dr.GetOrdinal("CategoryId")),
                    CategoryName = dr.GetFieldValue<string>(dr.GetOrdinal("CategoryName")),
                });
            }

            return categories;
        }
    }
}
