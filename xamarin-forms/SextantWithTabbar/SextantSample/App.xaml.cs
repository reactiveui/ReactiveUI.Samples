using System;
using ReactiveUI;
using Sextant;
using Sextant.XamForms;
using SextantSample.ViewModels;
using SextantSample.Views;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Sextant.Sextant;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SextantSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RxApp.DefaultExceptionHandler = new SextantDefaultExceptionHandler();

            Instance.InitializeForms();

            Locator
                .CurrentMutable
                .RegisterView<TabView, TabViewModel>()
                .RegisterView<HomeView, HomeViewModel>()
                .RegisterView<FirstModalView, FirstModalViewModel>()
                .RegisterView<SecondModalView, SecondModalViewModel>()
                .RegisterView<RedView, RedViewModel>()
                .RegisterView<BlueView, BlueViewModel>()
                .RegisterView<MainNavigationView, MainNavigationViewModel>()
                .RegisterNavigationView(() => new BlueNavigationView());

            Locator
                .Current
                .GetService<IViewStackService>()
                .PushPage(new MainNavigationViewModel(null), null, true, false)
                .Subscribe();

            MainPage = Locator.Current.GetNavigationView();
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
