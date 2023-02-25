using System.ComponentModel.DataAnnotations.Schema;
using WesaamEcomerce.Common.Enums;
namespace WesaamEcomerce.EntityFramework.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }

        // discount percentage on the product
        public double DiscountPercentage { get; set; } = 0;
        public double Price { get; set; }
        public double SellingPrice { get => Price - (Price * DiscountPercentage); }
        public List<Country> SellingCountries { get; set; }
        public string Description { get; set; }
        public List<string>? ImageUrls { get; set; }
        public List<string>? StoryImageUrls { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
