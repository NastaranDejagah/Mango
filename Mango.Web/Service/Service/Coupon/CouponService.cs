using Mango.Web.Models;
using Mango.Web.Models.Coupon;
using Mango.Web.Service.IService;
using Mango.Web.Service.IService.Coupon;
using Mango.Web.Utility;

namespace Mango.Web.Service.Service.Coupon
{
    public class CouponService(IBaseService baseService) : ICouponService
    {
        public async Task<ResponseDto?> CreateAsync(CouponDto couponDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SendType.ApiType.Post,
                Data = couponDto,
                Url = SendType.CouponAPIBase + "/api/coupon/"

            });
        }

        public async Task<ResponseDto?> DeleteAsync(int id)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SendType.ApiType.Delete,
                Url = SendType.CouponAPIBase + "/api/coupon/" + id

            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SendType.ApiType.Get,
                Url = SendType.CouponAPIBase+"/api/coupon"

            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SendType.ApiType.Get,
                Url = SendType.CouponAPIBase + "/api/coupon/GetByCode"+couponCode

            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SendType.ApiType.Get,
                Url = SendType.CouponAPIBase + "/api/coupon/" + id

            });
        }

        public async Task<ResponseDto?> UpdateAsync(CouponDto couponDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SendType.ApiType.Put,
                Data = couponDto,
                Url = SendType.CouponAPIBase + "/api/coupon/"

            });
        }
    }
}
