using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JoggerPantsWPF.Attributes;

namespace JoggerPantsWPF.Converters
{
    /// <summary>
    /// <see cref="EnumToDisplayNameConverter"/> is a converter that converts to enum attached <see cref="string"/> <see cref="EnumDisplayNameAttribute.Name"/>.
    /// </summary>
    public class EnumToDisplayNameConverter : BaseOnewayConverter
    {
        /// <summary>
        /// case when <paramref name="value"/> is <see cref="System.Enum"/> then it will return the <see cref="EnumDisplayNameAttribute.Name"/> of the <paramref name="value"/>.<br/>
        /// case when <paramref name="value"/> is <see langword="null"/> it will return "Null".<br/>
        /// case when <paramref name="value"/> is not <see cref="Enum"/> it will return "NaN".
        /// </summary>
        /// <param name="value"><see cref="Enum"/> value for change to <see cref="string"/></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "Null";

            if (value is System.Enum valueAsEnum)
            {
                var enumDescription = Helpers.EnumHelper.GetEnumDisplayName(valueAsEnum);
                return enumDescription;
            }
            else
                return "NaN";
        }
    }
}
