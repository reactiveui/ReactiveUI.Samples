using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReactiveUI.Samples.Suspension.Drivers;
using ReactiveUI.Samples.Suspension.ViewModels;
using ReactiveUI.Samples.Suspension.Views;
using Splat;

namespace ReactiveUI.Samples.Suspension
{
    public class App : Application
    {
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            var suspension = new AutoSuspendHelper(ApplicationLifetime);
            RxApp.SuspensionHost.CreateNewAppState = () => new MainViewModel();
            RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver("appstate.json"));
            suspension.OnFrameworkInitializationCompleted();

            Locator.CurrentMutable.RegisterConstant<IScreen>(RxApp.SuspensionHost.GetAppState<MainViewModel>());
            Locator.CurrentMutable.Register<IViewFor<SearchViewModel>>(() => new SearchView());
            Locator.CurrentMutable.Register<IViewFor<LoginViewModel>>(() => new LoginView());
            
            new MainView { DataContext = Locator.Current.GetService<IScreen>() }.Show();
            base.OnFrameworkInitializationCompleted();
        }
    }
}