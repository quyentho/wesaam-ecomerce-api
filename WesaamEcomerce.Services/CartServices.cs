using Microsoft.EntityFrameworkCore;
using WesaamEcomerce.EntityFramework;
using WesaamEcomerce.EntityFramework.Models;

namespace WesaamEcomerce.Services
{
    public class CartServices : BaseServices<Cart> 
    {
        public CartServices(ApplicationDbContext dbContext): base(dbContext)
        {
        }
    }
}