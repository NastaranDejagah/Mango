﻿namespace Mango.Services.CouponAPI.Model.Dto
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAccount { get; set; }
    }
}