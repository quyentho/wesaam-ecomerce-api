using WesaamEcomerce.Common.Enums;

namespace WesaamEcomerce.API.DTOs.Product;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Thumbnail { get; set; }

    // discount percentage on the product
    public double DiscountPercentage { get; set; } = 0;
    public double Price { get; set; } = 0;
    public List<Country> SellingCountries { get; set; }
    public string Description { get; set; }
    public int? CategoryId { get; set; }
}
