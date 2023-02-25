using WesaamEcomerce.API.DTOs.Category;
using WesaamEcomerce.Common.Enums;

namespace WesaamEcomerce.API.DTOs.Product;

public class ProductDto
{
    public string Name { get; set; }
    public string Thumbnail { get; set; }

    // discount percentage on the product
    public double DiscountPercentage { get; set; } = 0;
    public double Price { get; set; } = 0;
    public double SellingPrice { get => Price - Price * DiscountPercentage; }
    public List<Country> SellingCountries { get; set; }
    public string Description { get; set; }
    public List<string>? ImageUrls { get; set; }
    public List<string>? StoryImageUrls { get; set; }
    public int? CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
}
