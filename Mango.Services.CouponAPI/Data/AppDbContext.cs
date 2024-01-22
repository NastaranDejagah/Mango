using Mango.Services.CouponAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons { get; set; }
    }
}
