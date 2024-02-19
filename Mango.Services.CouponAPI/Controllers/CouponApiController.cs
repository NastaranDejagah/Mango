using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Model;
using Mango.Services.CouponAPI.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/Coupon")]
    [ApiController]
    public class CouponApiController(AppDbContext dbAppContext, IMapper mapper) : ControllerBase
    {
        private readonly ResponseDto _response = new ResponseDto();

        [HttpGet] 
        public ResponseDto Get()
        {
            try
            {
                var couponList = dbAppContext.Coupons.ToList();
                _response.Result = mapper.Map<List<Coupon>>(couponList);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                var coupon = dbAppContext.Coupons.FirstOrDefault(x=>x.CouponId == id);
                _response.Result = mapper.Map<CouponDto>(coupon);

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto Get(string code)
        {
            try
            {
                var coupon = dbAppContext.Coupons.FirstOrDefault(x => x.CouponCode.ToLower() == code.ToLower());
                _response.Result = mapper.Map<CouponDto?>(coupon);

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }

        [HttpPost]
        public ResponseDto Create([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = mapper.Map<Coupon>(couponDto);
                dbAppContext.Coupons.Add(coupon);
                dbAppContext.SaveChanges();

                _response.Result = mapper.Map<CouponDto>(coupon);

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }


        [HttpPut]
        public ResponseDto Update([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = mapper.Map<Coupon>(couponDto);
                dbAppContext.Coupons.Update(coupon);
                dbAppContext.SaveChanges();

                _response.Result = mapper.Map<CouponDto>(coupon);

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                var coupon = dbAppContext.Coupons.Find(id);
                if (coupon != null)
                {
                    dbAppContext.Coupons.Remove(coupon);
                    dbAppContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }
    }
}
