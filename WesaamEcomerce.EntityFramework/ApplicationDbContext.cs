using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql;
using WesaamEcomerce.Common.Enums;
using WesaamEcomerce.EntityFramework.Converters;
using WesaamEcomerce.EntityFramework.Models;

namespace WesaamEcomerce.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Country>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<PaymentType>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var valueComparer = new ValueComparer<List<Country>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            modelBuilder.HasPostgresEnum<Country>();
            modelBuilder.HasPostgresEnum<PaymentType>();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

}
