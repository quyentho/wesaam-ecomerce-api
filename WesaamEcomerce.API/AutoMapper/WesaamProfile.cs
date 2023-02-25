using AutoMapper;
using WesaamEcomerce.API.DTOs.Category;
using WesaamEcomerce.API.DTOs.Coupon;
using WesaamEcomerce.API.DTOs.Product;
using WesaamEcomerce.EntityFramework.Models;

namespace WesaamEcomerce.API.AutoMapper
{
    internal class WesaamProfile : Profile
    {
        public WesaamProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<CreateCouponDto, Coupon>();
        }
    }
}
