using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Mango.Services.CouponAPI.Model
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
