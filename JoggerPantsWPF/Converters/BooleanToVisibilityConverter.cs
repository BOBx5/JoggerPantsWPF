using System;
using System.Globalization;
using System.Windows;

namespace JoggerPantsWPF.Converters
{
    /// <summary>
    /// <see cref="BooleanToVisibilityConverter"/> is a converter that converts a <see cref="bool"/> value to a <see cref="Visibility"/> value.<br/>
    /// </summary>
    public class BooleanToVisibilityConverter : BaseOnewayConverter
    {
        /// <summary>
        /// <see cref="BooleanToVisibilityConverter"/> is a converter that converts a <see cref="bool"/> value to a <see cref="Visibility"/> value.<br/>
        /// </summary>
        /// <param name="value"><see cref="bool"/> value to use as the <see cref="Visibility"/>. if <paramref name="value"/> is <see langword="true"/>, return [<see cref="Visibility.Visible"/>] by default.</param>
        /// <param name="parameter"> is the <see cref="bool"/> value for inverting <paramref name="value"/></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (TryConvertValueToBool(value, out bool _valueAsBool))
            {
                if(TryConvertValueToBool(parameter, out bool _invertParam) && _invertParam == true)
                {
                    _valueAsBool = !_valueAsBool;
                }
                return _valueAsBool ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Visible;
        }
        private bool TryConvertValueToBool(object input, out bool outBoolValue)
        {
            if (input is bool _valueAsBool)
            {
                outBoolValue = _valueAsBool;
                return true;
            }
            else if (input is string _stringValue)
            {
                if (_stringValue.ToUpper() == "TRUE")
                {
                    outBoolValue = true;
                    return true;
                }
                else if (_stringValue.ToUpper() == "FALSE")
                {
                    outBoolValue = false;
                    return true;
                }
                else if (bool.TryParse(_stringValue, out bool _parsedBoolValue))
                {
                    outBoolValue = _parsedBoolValue;
                    return true;
                }
            }
            
            outBoolValue = false;
            return false;
        }
    }
}
