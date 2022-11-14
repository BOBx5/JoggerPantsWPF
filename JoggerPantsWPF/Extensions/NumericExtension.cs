using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoggerPantsWPF.Extensions
{
    public static class NumericExtension
    {
        private static readonly string[] SizeSuffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        /// <summary>
        /// <see cref="long"/> to bytes suffix 
        /// </summary>
        /// <param name="value">value of bytes to convert string with suffix</param>
        /// <param name="decimalPlaces">decimal point place. default is 1</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string SizeSuffix(this long value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0)
                throw new ArgumentOutOfRangeException("decimalPlaces");
            
            if (value < 0) 
                return "-" + SizeSuffix(-value, decimalPlaces); 
            
            if (value == 0) 
                return string.Format("{0:n" + decimalPlaces + "} B", 0); 

            // suffixIndex is 0 for bytes, 1 for KB, 2, for MB,... etc.
            int suffixIndex = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (suffixIndex * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                suffixIndex += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[suffixIndex]);
        }
    }
}
