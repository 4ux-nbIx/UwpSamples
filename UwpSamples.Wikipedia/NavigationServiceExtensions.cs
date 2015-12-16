namespace UwpSamples.Wikipedia
{
    #region Namespace Imports

    using System;

    using Prism.Windows.Navigation;

    #endregion

    internal static class NavigationServiceExtensions
    {
        #region Public Methods

        public static Type GetViewModelType(Type viewType)
        {
            string viewModelTypeName = viewType.FullName.Replace(".Views.", ".ViewModels.")
                .Replace("." + viewType.Name, "." + viewType.Name + "Model");

            return GetAppType(viewModelTypeName);
        }

        public static Type GetViewType(string viewModelTypeName)
        {
            string viewTypeName = viewModelTypeName.Replace(".ViewModels.", ".Views.");
            viewTypeName = viewTypeName.Remove(viewTypeName.Length - 5);

            return GetAppType(viewTypeName);
        }

        public static bool Navigate<TViewModel>(this INavigationService navigationService)
            => navigationService.Navigate(typeof(TViewModel).FullName, null);

        #endregion

        #region Methods

        private static Type GetAppType(string viewTypeName)
        {
            Type type = typeof(NavigationServiceExtensions);
            return Type.GetType(type.AssemblyQualifiedName.Replace(type.FullName, viewTypeName));
        }

        #endregion
    }
}