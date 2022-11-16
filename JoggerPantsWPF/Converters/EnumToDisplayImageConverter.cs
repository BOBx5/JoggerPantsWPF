using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace JoggerPantsWPF.Converters
{
    /// <summary>
    /// <see cref="EnumToDisplayImageConverter"/> is a converter that is used to convert an enum value to a <see cref="System.Drawing.Bitmap"/>.
    /// </summary>
    public class EnumToDisplayImageConverter : BaseOnewayConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is System.Enum valueAsEnum)
            {
                var enumImage = Helpers.EnumHelper.GetEnumDisplayImage(valueAsEnum);
                return enumImage;
            }
            return null;
        }
    }
}
