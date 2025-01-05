using DotnetShop.Discount.Grpc.Models;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace DotnetShop.Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
        : DiscountProtoService.DiscountProtoServiceBase
    {
        public override  async Task<GetAllDiscountsResponse> GetAllDiscounts(GetAllDiscountsRequest request, ServerCallContext context)
        {
            var result = await dbContext.Coupons.Select(x => new CouponModel
            {
                Id = x.Id,
                ProductGuid = x.ProductGuid.ToString(),
                Description = x.Description,
                Amount = (int)x.Amount
            }).ToListAsync();

            var response = new GetAllDiscountsResponse();
            response.Coupon.Add(result);

            return response;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons
                .FirstOrDefaultAsync(x => x.ProductGuid.ToString().ToLower() == request.ProductGuid.ToLower());

            coupon ??= new Coupon { Id = 0, ProductGuid = new Guid(), Amount = 0, Description = "No Discount Description." };

            logger.LogInformation($"Discount is retrieved for ProductId : {coupon.ProductGuid}, Amount : {coupon.Amount}");

            var couponModel = new CouponModel
            {
                Id = coupon.Id,
                ProductGuid = coupon.ProductGuid.ToString(),
                Description = coupon.Description,
                Amount = (int)coupon.Amount
            };

            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            if (request.Coupon.ProductGuid == null || request.Coupon.Amount == 0)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
            }

            var coupon = new Coupon
            {
                ProductGuid = new Guid(request.Coupon.ProductGuid),
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };

            dbContext.Add(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation($"Discount is successfully created. Discount Id : {coupon.Id}");

            return new CouponModel
            {
                Id = coupon.Id,
                ProductGuid = coupon.ProductGuid.ToString(),
                Description = coupon.Description,
                Amount = (int)coupon.Amount
            };
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = new Coupon
            {
                Id = request.Coupon.Id,
                ProductGuid = new Guid(request.Coupon.ProductGuid),
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };

            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
            }

            dbContext.Coupons.Update(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation($"Discount is successfully updated. Discount Id : {coupon.Id}");

            var couponModel = new CouponModel
            {
                Id = coupon.Id,
                ProductGuid = coupon.ProductGuid.ToString(),
                Description = coupon.Description,
                Amount = (int)coupon.Amount
            };

            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = dbContext.Coupons.Find(request.Id);

            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount Id: {request.Id} is not found."));
            }

            dbContext.Remove(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation($"Discount is successfully deleted. Discount Id: {request.Id}");

            return new DeleteDiscountResponse { Success = true };
        }
    }
}
