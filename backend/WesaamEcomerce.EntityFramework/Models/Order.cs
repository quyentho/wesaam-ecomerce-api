using System.ComponentModel.DataAnnotations.Schema;
using WesaamEcomerce.Common.Enums;
using WesaamEcomerce.Common.Helpers;

namespace WesaamEcomerce.EntityFramework.Models
{
    public class Order: BaseModel
    {
        public int CartId { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        public virtual List<Coupon>? AppliedCoupons { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
