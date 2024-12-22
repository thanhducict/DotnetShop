using DotnetShop.Catalog.API.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace DotnetShop.Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CatalogDb")!;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var products = new List<Product>();

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("Product_Get", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter(@"PageNumber", pageNumber));
                cmd.Parameters.Add(new SqlParameter(@"PageSize", pageSize));

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                await Task.Run(() => da.Fill(dt));

                if (dt.Rows.Count > 0)
                {
                    products = dt.AsEnumerable().Select(p => new Product
                    {
                        ProductId = p.Field<int>("ProductId"),
                        ProductGuid = p.Field<Guid>("ProductGuid"),
                        ProductName = p.Field<string>("ProductName"),
                        ShortDescription = p.Field<string>("ShortDescription"),
                        LongDescription = p.Field<string>("LongDescription"),
                        ImageUrls = string.IsNullOrEmpty(p.Field<string>("ImageUrls"))
                         ? []
                            : JsonSerializer.Deserialize<List<string>>(p.Field<string>("ImageUrls"))!,
                        ImageThumbnailUrl = p.Field<string>("ImageThumbnailUrl"),
                        Price = p.Field<decimal>("Price"),
                        CategoryId = p.Field<int>("CategoryId")
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: {exception}", ex.Message);
                return [];
            }

            return products;
        }

        public async Task<Product> GetProductById(int productId, CancellationToken cancellationToken)
        {
            Product? product = null;

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Product WHERE ProductId = @ProductId", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter(@"ProductId", productId));

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                await Task.Run(() => da.Fill(dt));

                if (dt.Rows.Count > 0)
                {
                    product = dt.AsEnumerable().Select(p => new Product
                    {
                        ProductId = p.Field<int>("ProductId"),
                        ProductGuid = p.Field<Guid>("ProductGuid"),
                        ProductName = p.Field<string>("ProductName"),
                        ShortDescription = p.Field<string>("ShortDescription"),
                        LongDescription = p.Field<string>("LongDescription"),
                        ImageUrls = string.IsNullOrEmpty(p.Field<string>("ImageUrls"))
                            ? []
                            : JsonSerializer.Deserialize<List<string>>(p.Field<string>("ImageUrls"))!,
                        ImageThumbnailUrl = p.Field<string>("ImageThumbnailUrl"),
                        Price = p.Field<decimal>("Price"),
                        CategoryId = p.Field<int>("CategoryId")
                    }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: {exception}", ex.Message);
            }

            return product ?? new Product();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            string sql = "SELECT * FROM Product; SELECT * FROM Category";

            DataSet ds = new DataSet();
            DataTable productTable = new DataTable();
            DataTable categoryTable = new DataTable();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            await Task.Run(() => da.Fill(ds));

            if (ds.Tables.Count > 0)
            {
                productTable = ds.Tables[0];
                categoryTable = ds.Tables[1];
            }

            if (productTable.Rows.Count > 0)
            {
                var categories = categoryTable.AsEnumerable().Select(c => new Category
                {
                    CategoryId = c.Field<int>("CategoryId"),
                    CategoryGuid = c.Field<Guid>("CategoryGuid"),
                    CategoryName = c.Field<string>("CategoryName")
                }).ToList();

                var selectedCategory = categories.Where(c => c.CategoryName.ToLower().Equals(categoryName.ToLower())).SingleOrDefault();

                var products = productTable.AsEnumerable().Select(p => new Product
                {
                    ProductId = p.Field<int>("ProductId"),
                    ProductGuid = p.Field<Guid>("ProductGuid"),
                    ProductName = p.Field<string>("ProductName"),
                    ShortDescription = p.Field<string>("ShortDescription"),
                    LongDescription = p.Field<string>("LongDescription"),
                    ImageUrls = string.IsNullOrEmpty(p.Field<string>("ImageUrls"))
                        ? []
                        : JsonSerializer.Deserialize<List<string>>(p.Field<string>("ImageUrls"))!,
                    ImageThumbnailUrl = p.Field<string>("ImageThumbnailUrl"),
                    Price = p.Field<decimal>("Price"),
                    CategoryId = p.Field<int>("CategoryId"),
                }).ToList();

                if (selectedCategory != null)
                {
                    return products.Where(p => p.CategoryId ==  selectedCategory.CategoryId).ToList();
                }
                else
                {
                    return products;
                }
            }
            else
            {
                return [];
            }
        }

        public async Task<int> CreateProduct(Product product, CancellationToken cancellationToken)
        {
            int productId = 0;

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                using SqlCommand cmd = new SqlCommand("Product_Create", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter { ParameterName = "@ProductId", Value = productId, IsNullable = false,
                        DbType = DbType.Int32, Direction = ParameterDirection.Output });
                cmd.Parameters.Add(new SqlParameter("@ProductGuid", product.ProductGuid));
                cmd.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                cmd.Parameters.Add(new SqlParameter("@ShortDescription", product.ShortDescription));
                cmd.Parameters.Add(new SqlParameter("@LongDescription", product.LongDescription));
                cmd.Parameters.Add(new SqlParameter("@ImageUrls", JsonSerializer.Serialize(product.ImageUrls)));
                cmd.Parameters.Add(new SqlParameter("@ImageThumbnailUrl", product.ImageThumbnailUrl));
                cmd.Parameters.Add(new SqlParameter("@Price", product.Price));
                cmd.Parameters.Add(new SqlParameter("@CategoryId", product.CategoryId));

                await cmd.ExecuteScalarAsync(cancellationToken);
                productId = (int)cmd.Parameters["@ProductId"].Value;

                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: {exception}", ex.Message);
                return productId;
            }

            return productId;
        }


        public async Task<bool> UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                using SqlCommand cmd = new SqlCommand("Product_Update", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                cmd.Parameters.Add(new SqlParameter("@ProductGuid", product.ProductGuid));
                cmd.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                cmd.Parameters.Add(new SqlParameter("@ShortDescription", product.ShortDescription));
                cmd.Parameters.Add(new SqlParameter("@LongDescription", product.LongDescription));
                cmd.Parameters.Add(new SqlParameter("@ImageUrls", JsonSerializer.Serialize(product.ImageUrls)));
                cmd.Parameters.Add(new SqlParameter("@ImageThumbnailUrl", product.ImageThumbnailUrl));
                cmd.Parameters.Add(new SqlParameter("@Price", product.Price));
                cmd.Parameters.Add(new SqlParameter("@CategoryId", product.CategoryId));

                await cmd.ExecuteNonQueryAsync(cancellationToken);

                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: {exception}", ex.Message);
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                using SqlCommand cmd = new SqlCommand("Product_Delete", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProductId", productId));

                await cmd.ExecuteNonQueryAsync(cancellationToken);

                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: {exception}", ex.Message);
                return false;
            }

            return true;
        }
    }
}
