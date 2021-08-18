using System;
using System.Reflection;
using System.Threading;
using ReactiveUI;
using Sextant;
using Sextant.XamForms;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Parameters
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RxApp.DefaultExceptionHandler = new NavigationExceptionHandler();

            Locator
                .CurrentMutable
                .RegisterNavigationView(() => new NavigationView(RxApp.MainThreadScheduler, RxApp.TaskpoolScheduler, ViewLocator.Current))
                .RegisterParameterViewStackService()
                .RegisterView<PassPage, PassViewModel>()
                .RegisterView<ReceivedPage, ReceivedViewModel>();

            Locator
                .Current
                .GetService<IParameterViewStackService>()
                .PushPage(new PassViewModel(), null, true, false)
                .Subscribe();

            MainPage = Locator.Current.GetNavigationView("NavigationView");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
