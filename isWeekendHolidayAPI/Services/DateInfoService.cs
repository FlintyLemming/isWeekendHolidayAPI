using isWeekendHolidayAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace isWeekendHolidayAPI.Services
{
    public class DateInfoService
    {
        static List<DateInfo> HolidayLists { get; }
        static DateInfoService()
        {
            HolidayLists = new List<DateInfo>
            {
                new DateInfo { Date = "", HolidayName = "" },
            };
        }

        public static DateInfo Get(string date) => HolidayLists.Last();
    }
}