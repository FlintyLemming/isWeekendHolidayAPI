namespace isWeekendHolidayAPI.Models
{
    public class DateInfo
    {
        public string Date { get; set; }
        public bool IsWorkday { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsWeekend { get; set; }
        public string HolidayName { get; set; }
        public int Week { get; set; }
    }
}