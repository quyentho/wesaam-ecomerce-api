using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WesaamEcomerce.Common.Helpers
{
    public class DateTimeHelper
    {
        public static DateTime GetVietnamTime(DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.UtcNow;
            }

            return TimeZoneInfo.ConvertTime(dateTime.Value, GetVietnamTimeZone());
        }
        public static TimeZoneInfo GetVietnamTimeZone()
        {
            TimeZoneInfo vietnamZone;
            try
            {
                vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            }

            return vietnamZone;
        }

    }
}