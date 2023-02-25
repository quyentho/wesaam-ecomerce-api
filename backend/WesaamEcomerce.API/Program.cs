using Microsoft.EntityFrameworkCore;
using WesaamEcomerce.EntityFramework;
using WesaamEcomerce.EntityFramework.Models;
using WesaamEcomerce.Services;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers(config => config.SuppressAsyncSuffixInActionNames = false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContextFactory<ApplicationDbContext>(
    dbContextOptionsBuilder =>
    {
        dbContextOptionsBuilder.UseLazyLoadingProxies();
        DbContextOptionsConfigurer.Configure(dbContextOptionsBuilder, builder.Configuration.GetConnectionString("Default"));
    }
); ;
builder.Services.AddScoped<IServices<Product>, ProductServices>();
builder.Services.AddScoped<IServices<Category>, CategoryServices>();
builder.Services.AddScoped<IServices<Coupon>, CouponServices>();
builder.Services.AddScoped<IServices<Cart>, CartServices>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
