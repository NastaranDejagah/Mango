using Mango.Web.Models;
using Mango.Web.Models.Coupon;
using Mango.Web.Service.IService.Coupon;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mango.Web.Controllers
{
    public class CouponController(ICouponService couponService) : Controller
    {
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? response = await couponService.GetAllCouponAsync();
            if (response is { IsSuccess: true })
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>
                    (Convert.ToString(response.Result) ?? string.Empty);
            }

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await couponService.CreateAsync(model);
                if (response is { IsSuccess: true })
                {
                    return RedirectToAction("CouponIndex");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await couponService.GetCouponByIdAsync(couponId);
            if (response is { IsSuccess: true })
            {
                var model = JsonConvert.DeserializeObject<CouponDto>
                    (Convert.ToString(response.Result) ?? string.Empty);

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto model)
        {
            ResponseDto? response = await couponService.DeleteAsync(model.CouponId);
            if (response is { IsSuccess: true })
            {
                 return RedirectToAction("CouponIndex");
            }

            return NotFound();
        }
    }
}
