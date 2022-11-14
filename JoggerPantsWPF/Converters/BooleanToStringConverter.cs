using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JoggerPantsWPF.Converters
{
    /// <summary>
    /// <see cref="BooleanToStringConverter"/> is a converter that converts a <see cref="bool"/> value to a <see cref="string"/> value.<br/>
    /// </summary>
    public class BooleanToStringConverter : BaseOnewayConverter
    {
        /// <summary>
        /// <see cref="BooleanToStringConverter"/> is a converter that converts a <see cref="bool"/> value to a <see cref="Visibility"/> value.<br/>
        /// </summary>
        /// <param name="value"><see cref="bool"/> value to use as the <see cref="string"/>. if <paramref name="value"/> is <see langword="true"/>, return first <see cref="string"/> recieved by <paramref name="parameter"/>.</param>
        /// <param name="parameter">Array of <see cref="string"/>s. You can narrate <see cref="string"/>s with "|" characters </param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string rtnTrue = bool.TrueString;
            string rtnFalse = bool.FalseString;
            string rtnNan = "NaN";

            if (parameter is string paramAsString)
            {
                var splits = paramAsString.Split("|", StringSplitOptions.None);
                switch (splits.Length)
                {
                    case 0:
                        break;
                    case 1:
                        rtnTrue = splits[0];
                        break;
                    case 2:
                        rtnTrue = splits[0];
                        rtnFalse = splits[1];
                        break;
                    case 3:
                        rtnTrue = splits[0];
                        rtnFalse = splits[1];
                        rtnNan = splits[3];
                        break;
                }
            }
            
            if (value is null)
                return rtnNan;
            
            if (value is bool Value)
                return Value ? rtnTrue : rtnFalse;
            
            return rtnNan;

        }
    }
}
