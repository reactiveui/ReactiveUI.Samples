using System;
using ReactiveUI;
using Sextant;
using Sextant.Abstractions;
using Sextant.XamForms;
using Splat;
using Xamarin.Forms;

namespace Packages
{
    public class Startup
    {
        public Startup(IDependencyResolver dependencyResolver = null)
        {
            if (dependencyResolver == null)
            {
                dependencyResolver = new ModernDependencyResolver();
            }

            RxApp.DefaultExceptionHandler = new PackagesExceptionHandler();
            RegisterServices(dependencyResolver);
            RegisterViewModels(dependencyResolver);
            RegisterViews(dependencyResolver);
            Build(dependencyResolver);
        }

        private void Build(IDependencyResolver dependencyResolver) =>
            Locator.SetLocator(dependencyResolver);

        private void RegisterViews(IDependencyResolver dependencyResolver)
        {
            dependencyResolver.RegisterView<NuGetPackageListPage, NuGetPackageListViewModel>();
            dependencyResolver.RegisterView<NuGetPackageDetailPage, NuGetPackageDetailViewModel>();
        }

        private void RegisterViewModels(IDependencyResolver dependencyResolver)
        {
            dependencyResolver.RegisterViewModel(() =>
                new NuGetPackageListViewModel(dependencyResolver.GetService<IParameterViewStackService>(),
                    dependencyResolver.GetService<INuGetService>()));
            dependencyResolver.RegisterViewModel<NuGetPackageDetailViewModel>();
        }

        private void RegisterServices(IDependencyResolver dependencyResolver)
        {
            var navigationView = new NavigationView();
            dependencyResolver.RegisterNavigationView(() => navigationView);
            dependencyResolver.RegisterLazySingleton<IParameterViewStackService>(() => new ParameterViewStackService(navigationView));
            dependencyResolver.RegisterLazySingleton<IViewModelFactory>(() => new DefaultViewModelFactory());
            dependencyResolver.InitializeReactiveUI();
            dependencyResolver.RegisterLazySingleton<INuGetService>(() => new NuGetService());
        }

        public Page NavigateToStart<T>()
            where T : IViewModel
        {
            Locator.Current.GetService<IParameterViewStackService>().PushPage<T>().Subscribe();
            return Locator.Current.GetNavigationView(nameof(NavigationView));
        }
    }
}
