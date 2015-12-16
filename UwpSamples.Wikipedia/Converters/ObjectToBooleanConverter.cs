namespace UwpSamples.Wikipedia.Converters
{
    #region Namespace Imports

    using System;

    using Windows.UI.Xaml.Data;

    #endregion

    public class ObjectToBooleanConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}