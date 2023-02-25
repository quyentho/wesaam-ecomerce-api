using Microsoft.EntityFrameworkCore;
using WesaamEcomerce.EntityFramework;
using WesaamEcomerce.EntityFramework.Models;

namespace WesaamEcomerce.Services
{
    public class CategoryServices : BaseServices<Category>
    {
        public CategoryServices(ApplicationDbContext dbContext): base(dbContext)
        {
        }
    }
}