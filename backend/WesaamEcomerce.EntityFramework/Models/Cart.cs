using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WesaamEcomerce.Common.Helpers;
namespace WesaamEcomerce.EntityFramework.Models
{
    public class Cart : BaseModel
    {

        [Column(TypeName = "jsonb")]
        public List<Product> Products { get; set; } = new List<Product>();
        public virtual List<Coupon>? Coupons { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTimeHelper.GetVietnamTime();

        public double PreDiscountTotal { get => Products.Sum(p => p.SellingPrice); }
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public double Total
        {
            get
            {
                if (Coupons == null || Coupons.Count == 0)
                {
                    return PreDiscountTotal;
                }

                double total = PreDiscountTotal;
                // sum all discount percentages
                double discountPercentage = Coupons.Where(c => c.Percentage.HasValue).Sum(c => c.Percentage!.Value);

                // apply discount percentages
                total = PreDiscountTotal - (PreDiscountTotal * discountPercentage);

                // sum all fixed discount amount
                double couponDiscountAmount = Coupons.Where(c => c.Amount.HasValue).Sum(c => c.Amount!.Value);

                total -= couponDiscountAmount;

                return total;

            }
        }
    }
}
