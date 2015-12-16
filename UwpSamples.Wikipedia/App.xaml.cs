namespace UwpSamples.Wikipedia
{
    #region Namespace Imports

    using System;
    using System.Threading.Tasks;

    using Windows.ApplicationModel.Activation;

    using Autofac;

    using Prism.Mvvm;

    using UwpSamples.Wikipedia.Service;
    using UwpSamples.Wikipedia.ViewModels;

    #endregion

    sealed partial class App
    {
        #region Methods

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            builder.RegisterType<SearchViewModel>();

            RegisterTypeIfMissing<IWikipediaService, WikipediaService>(builder, true);
        }

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
                NavigationServiceExtensions.GetViewModelType);

            ViewModelLocationProvider.SetDefaultViewModelFactory(Resolve);
        }

        protected override Type GetPageType(string viewModelTypeName)
            => NavigationServiceExtensions.GetViewType(viewModelTypeName);

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs e)
        {
            NavigationService.Navigate<SearchViewModel>();

            return Task.CompletedTask;
        }

        #endregion
    }
}