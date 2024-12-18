using Microsoft.Data.Sqlite;

namespace DotnetShop.Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqliteConnection _sqliteConnection;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqliteConnection = new SqliteConnection(_configuration.GetConnectionString("DiscountDb"));
        }

        public Task<CouponModel> GetDiscountById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CouponModel> CreateDiscount(CouponModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CouponModel> UpdateDiscount(CouponModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CouponModel> DeleteDiscount(int id)
        {
            throw new NotImplementedException();
        }
    }
}
