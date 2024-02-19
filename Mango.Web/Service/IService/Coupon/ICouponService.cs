using Mango.Web.Models;
using Mango.Web.Models.Coupon;

namespace Mango.Web.Service.IService.Coupon
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteAsync(int id);
    }
}
