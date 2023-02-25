using Microsoft.EntityFrameworkCore;
using WesaamEcomerce.EntityFramework;
using WesaamEcomerce.EntityFramework.Models;

namespace WesaamEcomerce.Services
{
    public class ProductServices : BaseServices<Product>
    {
        public ProductServices(ApplicationDbContext dbContext): base(dbContext)
        {
        }
    }
}