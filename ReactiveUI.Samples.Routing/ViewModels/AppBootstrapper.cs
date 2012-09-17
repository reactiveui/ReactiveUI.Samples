using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using ReactiveUI.Routing;
using ReactiveUI.Samples.Routing.Views;

namespace ReactiveUI.Samples.Routing.ViewModels
{
    /* COOLSTUFF: What is the AppBootstrapper?
     * 
     * The AppBootstrapper is like a ViewModel for the WPF Application class.
     * Since Application isn't very testable (just like Window / UserControl), 
     * we want to create a class we can test. Since our application only has
     * one "screen" (i.e. a place we present Routed Views), we can also use 
     * this as our IScreen.
     * 
     * An IScreen is a ViewModel that contains a Router - practically speaking,
     * it usually represents a Window (or the RootFrame of a WinRT app). We 
     * should technically create a MainWindowViewModel to represent the IScreen,
     * but there isn't much benefit to split those up unless you've got multiple
     * windows.
     * 
     * AppBootstrapper is a good place to implement a lot of the "global 
     * variable" type things in your application. It's also the place where
     * you should configure your IoC container. And finally, it's the place 
     * which decides which View to Navigate to when the application starts.
     */
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public IRoutingState Router { get; private set; }

        public AppBootstrapper(IKernel testKernel = null, IRoutingState testRouter = null)
        {
            Router = testRouter ?? new RoutingState();
            var kernel = testKernel ?? CreateStandardKernel();

            // AppBootstrapper is a global variable, so bind up 
            kernel.Bind(typeof (IScreen), typeof(AppBootstrapper)).ToConstant(this);

            // Set up NInject to do DI
            RxApp.ConfigureServiceLocator(
                (iface, contract) => {
                    if (contract != null) return kernel.Get(iface, contract);
                    return kernel.Get(iface);
                },
                (iface, contract) => {
                    if (contract != null) return kernel.GetAll(iface, contract);
                    return kernel.GetAll(iface);
                },
                (realClass, iface, contract) => {
                    var binding = kernel.Bind(iface).To(realClass);
                    if (contract != null) binding.Named(contract);
                });

            // TODO: This is a good place to set up any other app 
            // startup tasks, like setting the logging level
            LogHost.Default.Level = LogLevel.Debug;

            // Navigate to the opening page of the application
            var welcomeVm = RxApp.GetService<IWelcomeViewModel>();
            Router.Navigate.Execute(welcomeVm);
        }

        IKernel CreateStandardKernel()
        {
            var ret = new StandardKernel();

            ret.Bind<IWelcomeViewModel>().To<WelcomeViewModel>();
            ret.Bind<IViewFor<IWelcomeViewModel>>().To<WelcomeView>();
            return ret;
        }
    }
}
