using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using isWeekendHolidayAPI.Models;
using isWeekendHolidayAPI.Services;
using System.Data;
using Newtonsoft.Json;
using System.IO;

namespace isWeekendHolidayAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateInfoController : ControllerBase
    {
        public DateInfoController()
        {
        }
        // GET action
        [HttpGet("{Date}")]
        public ActionResult<DateInfo> Get(string date)
        {
            DateTime datetime;
            // If date is not formatted
            try
            {
                datetime = Convert.ToDateTime(date);
            }
            catch
            {
                return NotFound();
            }
            
            // If date is fine
            var result = DateInfoService.Get("");

            // Date
            result.Date = date;
            // Week
            result.Week = Convert.ToInt32(datetime.DayOfWeek);
            // IsWeekend
            if (result.Week == 6 || result.Week == 0)
            {
                result.IsWeekend = true;
            }
            else
            {
                result.IsWeekend = false;
            }
            // IsHoliday HolidayName
            result.IsHoliday = false;
            result.HolidayName = "";
            var holidayList = new StreamReader("Assets/HolidayList.json");
            var holidayJson = holidayList.ReadToEnd();
            var holidayData = (DataTable)JsonConvert.DeserializeObject(holidayJson, typeof(DataTable));
            for (var a = 0; a < holidayData.Rows.Count; a++)
            {
                if (date == holidayData.Rows[a][0].ToString())
                {
                    result.IsHoliday = true;
                    result.HolidayName = holidayData.Rows[a][1].ToString();
                }
            }
            // IsWorkday
            result.IsWorkday = true;
            if (result.IsHoliday == true)
            {
                result.IsWorkday = false;
            }
            else if (result.IsWeekend == true)
            {
                result.IsWorkday = false;
                var workdayList = new StreamReader("Assets/WeekendWorkList.json");
                var workdayJson = workdayList.ReadToEnd();
                var workdayData = (DataTable)JsonConvert.DeserializeObject(workdayJson, typeof(DataTable));
                for (var a = 0; a < workdayData.Rows.Count; a++)
                {
                    if (date == workdayData.Rows[a][0].ToString())
                    {
                        result.IsWorkday = true;
                    }
                }
            }
            return result;
        }
    }
}