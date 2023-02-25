using Microsoft.EntityFrameworkCore;

namespace WesaamEcomerce.EntityFramework
{
    public class DbContextOptionsConfigurer
    {
        public static void Configure(DbContextOptionsBuilder builder, string connectionString)
        {
            builder.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        }
        
    }
}
