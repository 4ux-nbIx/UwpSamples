namespace UwpSamples.Wikipedia
{
    #region Namespace Imports

    using System;
    using System.Threading.Tasks;

    using Windows.ApplicationModel.Activation;

    using Autofac;

    using Prism.Mvvm;

    using UwpSamples.Wikipedia.ViewModels;

    #endregion

    sealed partial class App
    {
        #region Methods

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            builder.RegisterType<MainViewModel>();
        }

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(GetViewModelType);
            ViewModelLocationProvider.SetDefaultViewModelFactory(Resolve);
        }

        protected override Type GetPageType(string viewModelTypeName)
        {
            string viewTypeName = viewModelTypeName.Replace(".ViewModels.", ".Views.");
            viewTypeName = viewTypeName.Remove(viewTypeName.Length - 5);

            return GetAppType(viewTypeName);
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs e)
        {
            NavigationService.Navigate(typeof(MainViewModel).FullName, null);

            return Task.CompletedTask;
        }

        private Type GetAppType(string viewTypeName)
        {
            Type type = GetType();
            return Type.GetType(type.AssemblyQualifiedName.Replace(type.FullName, viewTypeName));
        }

        private Type GetViewModelType(Type viewType)
        {
            string viewModelTypeName = viewType.FullName.Replace(".Views.", ".ViewModels.")
                .Replace("." + viewType.Name, "." + viewType.Name + "Model");

            return GetAppType(viewModelTypeName);
        }

        #endregion
    }
}