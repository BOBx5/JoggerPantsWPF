using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoggerPantsWPF.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime FirstDateTimeOfMonth(this DateTime input)
        {
            return new DateTime(input.Year, input.Month, 1);
        }
        public static DateTime LastDateTimeOfMonth(this DateTime input)
        {
            int year = input.Year;
            int month = input.Month;
            int day = DateTime.DaysInMonth(input.Year, input.Month);
            return new DateTime(year, month, day, 23, 59, 59, 999);
        }
    }
}
