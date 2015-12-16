namespace UwpSamples.Wikipedia
{
    #region Namespace Imports

    using System;

    using Windows.System;
    using Windows.UI.Xaml;

    using Microsoft.Xaml.Interactivity;

    #endregion

    public class LaunchUriAction : DependencyObject, IAction
    {
        #region Constants and Fields

        public static readonly DependencyProperty UriProperty = DependencyProperty.Register(
            "Uri",
            typeof(string),
            typeof(LaunchUriAction),
            new PropertyMetadata(default(string)));

        #endregion

        #region Properties

        public string Uri
        {
            get
            {
                return (string)GetValue(UriProperty);
            }

            set
            {
                SetValue(UriProperty, value);
            }
        }

        #endregion

        #region Public Methods

        public object Execute(object sender, object parameter)
        {
            if (!string.IsNullOrWhiteSpace(Uri))
            {
                LaunchUri();
            }

            return null;
        }

        #endregion

        #region Methods

        private async void LaunchUri() => await Launcher.LaunchUriAsync(new Uri(Uri));

        #endregion
    }
}