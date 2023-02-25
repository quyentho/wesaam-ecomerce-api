using WesaamEcomerce.Common.Helpers;

namespace WesaamEcomerce.EntityFramework.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTimeHelper.GetVietnamTime();
        public bool IsActive { get; set; } = true;
    }
}
