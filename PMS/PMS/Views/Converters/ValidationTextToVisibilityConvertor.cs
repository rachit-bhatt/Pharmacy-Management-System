using PMS.Views.Controls;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PMS.Views.Converters
{
    public class ValidationTextToVisibilityConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ErrorPosition errorPosition
                && parameter is ErrorPosition errorPositionParameter)
                return errorPosition == errorPositionParameter ? Visibility.Visible : Visibility.Collapsed;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility errorVisibility
                && parameter is ErrorPosition errorPositionParameter)
                return errorPositionParameter;
            return ErrorPosition.Bottom;
        }
    }
}