using JoggerPantsWPF.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#nullable disable
namespace JoggerPantsWPF.Converters
{
    public class BooleanToColorConverter : BaseOnewayConverter
    {
        /// <summary>
        /// <see cref="BooleanToColorConverter"/> is a converter that converts a <see cref="bool"/> value to a <see cref="Color"/> value that recieved by <paramref name="parameter"/>.<br/>  
        /// </summary>
        /// <param name="value"><see cref="bool"/> value to use as the <see cref="Color"/>. if <paramref name="value"/> is <see langword="true"/>, return first <see cref="Color"/> recieved by <paramref name="parameter"/>.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Array of <see cref="Color"/>s. You can narrate <see cref="Color"/>s with "|" characters </param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorParams = parameterAsColors(parameter);
            if (value is bool valueAsBool)
            {
                var returnColor = valueAsBool ? colorParams[0] : colorParams[1];
                switch (targetType)
                {
                    case var t when t == typeof(System.Windows.Media.Color):
                        {
                            return valueAsBool ? colorParams[0] : colorParams[1];
                        }
                    case var t when t == typeof(System.Drawing.Color):
                        {
                            return valueAsBool ? colorParams[0].AsDrawingColor() : colorParams[1].AsDrawingColor();
                        }
                    case var t when t == typeof(System.Windows.Media.SolidColorBrush):
                        {
                            return valueAsBool ? new System.Windows.Media.SolidColorBrush(colorParams[0]) : new  System.Windows.Media.SolidColorBrush(colorParams[1]);
                        }
                }
            }

            throw new InvalidCastException($"{nameof(value)} cannot be cast to bool");
        }

        /// <summary>
        /// convert <paramref name="parameter"/> to <see cref="System.Windows.Media.Color"/>[]
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private System.Windows.Media.Color[] parameterAsColors(object parameter)
        {
            var splits = $"{parameter}".Split("|");
            System.Windows.Media.Color trueColor;
            System.Windows.Media.Color falseColor;
            switch (splits.Length)
            {
                case 0:
                    {
                        trueColor = System.Windows.Media.Colors.Black;
                        falseColor = System.Windows.Media.Colors.Transparent;
                        break;
                    }
                case 1:
                    {

                        trueColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(splits[0]);
                        falseColor = System.Windows.Media.Colors.Transparent;
                        break;
                    }
                case 2:
                    {
                        trueColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(splits[0]);
                        falseColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(splits[1]);
                        break;
                    }
                default:
                    {
                        trueColor = System.Windows.Media.Colors.Blue;
                        falseColor = System.Windows.Media.Colors.Red;
                        break;
                    }
            }
            return new System.Windows.Media.Color[] { trueColor, falseColor };
        }
    }
}
