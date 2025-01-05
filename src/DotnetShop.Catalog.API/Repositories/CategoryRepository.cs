using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace DotnetShop.Catalog.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(IConfiguration configuration, ILogger<CategoryRepository> logger)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CatalogDb")!;
            _logger = logger;
        }

        public async Task<IEnumerable<Category>> GetCategories(CancellationToken cancellationToken)
        {
            string sql = "SELECT * FROM Category";
            SqlDataReader dr;
            List<Category> categories = [];

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                using SqlCommand cmd = new SqlCommand(sql, connection);
                dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection, cancellationToken);
                while (dr.Read())
                {
                    categories.Add(new Category
                    {
                        CategoryId = dr.GetFieldValue<int>("CategoryId"),
                        CategoryGuid = dr.GetFieldValue<Guid>("CategoryGuid"),
                        CategoryName = dr.GetFieldValue<string>("CategoryName"),
                    });
                }
            }
            catch (SqlException sqlException)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < sqlException.Errors.Count; i++)
                {
                    sb.AppendLine("Index #: " + i.ToString());
                    sb.AppendLine("Type: " + sqlException.Errors[i].GetType().FullName);
                    sb.AppendLine("Message: " + sqlException.Errors[i].Message);
                    sb.AppendLine("Source: " + sqlException.Errors[i].Source);
                    sb.AppendLine("Number: " + sqlException.Errors[i].Number.ToString());
                    sb.AppendLine("State: " + sqlException.Errors[i].State.ToString());
                    sb.AppendLine("Class: " + sqlException.Errors[i].Class.ToString());
                    sb.AppendLine("Server: " + sqlException.Errors[i].Server);
                    sb.AppendLine("Procedure: " + sqlException.Errors[i].Procedure);
                    sb.AppendLine("LineNumber: " + sqlException.Errors[i].LineNumber.ToString());
                }

                _logger.LogInformation("Sql Exception: {sqlException}\nException: {exception}", sb.ToString(), sqlException.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: {exception}", ex.Message);
            }

            return categories;
        }

        public async Task<Guid?> CreateCategory(Category category, CancellationToken cancellationToken)
        {
            string sql = "INSERT INTO Category VALUES (@CategoryGuid, @CategoryName)";

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add(new SqlParameter("@CategoryGuid", category.CategoryGuid));
                cmd.Parameters.Add(new SqlParameter("@CategoryName", category.CategoryName));

                cmd.CommandType = CommandType.Text;
                await cmd.ExecuteNonQueryAsync(cancellationToken);

                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: {exception}", ex.Message);
                return null;
            }

            return category.CategoryGuid;
        }
    }
}
