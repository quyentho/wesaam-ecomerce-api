using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WesaamEcomerce.EntityFramework
{
    public class DbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var context = new ApplicationDbContext(
                builder
                .UseNpgsql("")
                .UseSnakeCaseNamingConvention()
                .Options);

            return context;
        }

    }
}
