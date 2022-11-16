using System;
using System.Globalization;
using System.Windows;

namespace JoggerPantsWPF.Converters
{
    /// <summary>
    /// <see cref="ScaledThicknessConverter"/> is a converter that converts a <see cref="double"/> value to a <see cref="Thickness"/> depends on scale.<br/>
    /// </summary>
    public class ScaledThicknessConverter : BaseOnewayConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"><see cref="double"/> value to use as scale. Thickness will return whenever scale has changed.</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Array of <see cref="double"/> value to use as Thickness.</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double Scale = 1;
            if (value == null || parameter == null)
                return new Thickness(0);

            if (value is double)
                Scale = (double)value;
            else if (value is string)
                Scale = System.Convert.ToDouble(value);

            string[] Params = $"{parameter}".Split(',');

            double left     = 0.0;
            double top      = 0.0;
            double right    = 0.0;
            double bottom   = 0.0;

            switch (Params.Length)
            {
                case 1:
                    left    = Scale * System.Convert.ToDouble(Params[0]);
                    top     = Scale * System.Convert.ToDouble(Params[0]);
                    right   = Scale * System.Convert.ToDouble(Params[0]);
                    bottom  = Scale * System.Convert.ToDouble(Params[0]);
                    break;

                case 2:
                    left    = Scale * System.Convert.ToDouble(Params[0]);
                    top     = Scale * System.Convert.ToDouble(Params[1]);
                    right   = Scale * System.Convert.ToDouble(Params[0]);
                    bottom  = Scale * System.Convert.ToDouble(Params[1]);
                    break;

                case 3:
                    left    = Scale * System.Convert.ToDouble(Params[0]);
                    top     = Scale * System.Convert.ToDouble(Params[1]);
                    right   = Scale * System.Convert.ToDouble(Params[2]);
                    bottom  = 0;
                    break;

                case 4:
                    left    = Scale * System.Convert.ToDouble(Params[0]);
                    top     = Scale * System.Convert.ToDouble(Params[1]);
                    right   = Scale * System.Convert.ToDouble(Params[2]);
                    bottom  = Scale * System.Convert.ToDouble(Params[3]);
                    break;
            }

            return new Thickness(left, top, right, bottom);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
