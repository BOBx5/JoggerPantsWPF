using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace JoggerPantsWPF.Converters
{
    public abstract class BaseOnewayConverter : MarkupExtension, IValueConverter
    {
        public BaseOnewayConverter() { }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
