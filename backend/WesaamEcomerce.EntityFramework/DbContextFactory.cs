using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WesaamEcomerce.EntityFramework
{
    public class DbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            DbContextOptionsConfigurer.Configure(builder, "Host=localhost;Database=WesaamEcomerceDB;Username=postgres;Password=password");

            var context = new ApplicationDbContext(builder.Options);

            return context;
        }

    }
}
