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
    /// <see cref="EnumToDescriptionConverter"/> is a converter that is used to convert an enum value to a string.
    /// </summary>
    public class EnumToDescriptionConverter : BaseOnewayConverter
    {
        public EnumToDescriptionConverter() { }
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "Null";

            if (value is System.Enum enumValue)
            {
                var enumDescription = Helpers.EnumHelper.GetDescription(enumValue);
                return enumDescription;
            }
            else
                return "NaN";
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
