using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoggerPantsWPF.Extensions
{
    public static class TimeSpanExtension
    {
        [Flags]
        public enum TimeSpanFormat
        {
            None = 0,        //   12    8    4    0
            d = 1 << 0,   // 0000 0000 0000 0001
            dd = 1 << 1,   // 0000 0000 0000 0010
            ddd = 1 << 2,   // 0000 0000 0000 0100
            dddd = 1 << 3,   // 0000 0000 0000 1000

            h = 1 << 4,   // 0000 0000 0001 0000
            hh = 1 << 5,   // 0000 0000 0010 0000
            m = 1 << 6,   // 0000 0000 0100 0000
            mm = 1 << 7,   // 0000 0000 1000 0000

            s = 1 << 8,   // 0000 0001 0000 0000
            ss = 1 << 9,   // 0000 0010 0000 0000

            // f 		= 1 << 12,  // 0001 0000 0000 0000
            // ff 		= 1 << 13,  // 0010 0000 0000 0000
            // fff 	    = 1 << 14,  // 0100 0000 0000 0000
        }

        /// <summary>
        /// <see cref="TimeSpan"/> <paramref name="span"/> 의 길이에 따라 자동으로 포멧을 확장하여 <see cref="string"/>로 반환합니다.<br/>
        /// 기본적으로는 <see cref="TimeSpanFormat"/> <paramref name="format"/> 의 포멧에 따라 표현하나, 상위 단위의 시간이 있는 경우 자동으로 확장하여 표현합니다. 
        /// </summary>
        /// <param name="span"></param>
        /// <param name="format">Default: "mm\m\ ss\s" ex) 07m 01s</param>
        /// <returns></returns>
        public static string ToAutoAppendString(this TimeSpan span, TimeSpanFormat format = TimeSpanFormat.mm | TimeSpanFormat.ss)
        {
            string pattern = @"h\h\ mm\m\ ss\s";

            if (format == TimeSpanFormat.None)
                return span.ToString(pattern);

            string DayFormat = "";
            bool DayExist = (int)span.Days >= 1;
            switch (format)
            {
                case var x when x.HasFlag(TimeSpanFormat.dddd):
                    DayFormat = "dddd\\d";
                    break;
                case var x when x.HasFlag(TimeSpanFormat.ddd):
                    DayFormat = "ddd\\d";
                    break;
                case var x when x.HasFlag(TimeSpanFormat.dd):
                    DayFormat = "dd\\d";
                    break;
                case var x when x.HasFlag(TimeSpanFormat.d):
                    DayFormat = "d\\d";
                    break;
                default:
                    if (DayExist)
                        DayFormat = "d\\d";
                    break;
            }

            string HourFormat = "";
            bool HourExist = (int)span.Hours >= 1;
            switch (format)
            {
                case var x when x.HasFlag(TimeSpanFormat.hh):
                    HourFormat = "hh\\h";
                    break;
                case var x when x.HasFlag(TimeSpanFormat.h):
                    HourFormat = "h\\h";
                    break;
                default:
                    if (DayExist && HourExist)
                        HourFormat = "hh\\h";
                    else if (HourExist)
                        HourFormat = "h\\h";
                    break;
            }

            string MinuteFormat = "";
            bool MinuteExist = (int)span.Minutes >= 1;
            switch (format)
            {
                case var x when x.HasFlag(TimeSpanFormat.mm):
                    MinuteFormat = "mm\\m";
                    break;
                case var x when x.HasFlag(TimeSpanFormat.m):
                    MinuteFormat = "m\\m";
                    break;
                default:
                    if (DayExist || HourExist)
                        MinuteFormat = "mm\\m";
                    break;
            }

            string SecondFormat = "";
            bool SecondExist = (int)span.Seconds >= 1;
            switch (format)
            {
                case var x when x.HasFlag(TimeSpanFormat.ss):
                    SecondFormat = "ss\\s";
                    break;
                case var x when x.HasFlag(TimeSpanFormat.s):
                    SecondFormat = "s\\s";
                    break;
                default:
                    if (DayExist || HourExist || MinuteExist)
                        SecondFormat = "ss\\s";
                    break;
            }

            var arr = new string[] { DayFormat, HourFormat, MinuteFormat, SecondFormat }.Where(i => !string.IsNullOrEmpty(i));
            pattern = string.Join(@"\ ", arr); // Escape " " 을 사이에 넣어 합친다.
            return span.ToString(pattern);
        }
    }
}
