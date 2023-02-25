using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WesaamEcomerce.Common.Enums;

namespace WesaamEcomerce.EntityFramework.Models
{
    public class Coupon: BaseModel
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }
        public string Code { get; set; }

        // the coupon gonna discount either by percentage or fixed amount
        // applied on enitre bill
        public double? Percentage { get; set; }
        public double? Amount { get; set; }

        public List<Country> SellingCountries { get; set; }

        // is show banner on the buyer mobile app
        public bool IsPublish { get; set; }

        // Is coupon applicable.
        public bool IsApply { get; set; }

    }
}