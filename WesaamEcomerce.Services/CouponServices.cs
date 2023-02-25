using Microsoft.EntityFrameworkCore;
using WesaamEcomerce.EntityFramework;
using WesaamEcomerce.EntityFramework.Models;

namespace WesaamEcomerce.Services
{
    public class CouponServices : BaseServices<Coupon>
    {
        public CouponServices(ApplicationDbContext dbContext): base(dbContext)
        {
        }
    }
}