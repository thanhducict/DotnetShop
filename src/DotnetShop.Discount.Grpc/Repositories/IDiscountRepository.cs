namespace DotnetShop.Discount.Grpc.Repositories
{
    public interface IDiscountRepository
    {
        Task<CouponModel> GetDiscountById(int id);
        Task<CouponModel> CreateDiscount(CouponModel model);
        Task<CouponModel> UpdateDiscount(CouponModel model);
        Task<CouponModel> DeleteDiscount(int id);
    }
}
