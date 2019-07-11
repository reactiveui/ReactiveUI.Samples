using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using Sextant;
using SextantSample.ViewModels;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace SextantSample.Views
{
    public partial class MainNavigationView : ReactiveTabbedPage<MainNavigationViewModel>
    {
        public MainNavigationView()
        {
            InitializeComponent();

            // To put the tab bar on bottom, Android
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            NavigationPage.SetHasNavigationBar(this, false);

            this.WhenActivated((CompositeDisposable disposables) =>
            {
                if (Children.Count == 0)
                {
                    ViewModel
                        .TabViewModels
                        .ForEach(x => Children.Add(InitializeTabNavigationService(x)));
                }
            });
        }

        private Page InitializeTabNavigationService(Func<IViewStackService, TabViewModel> createViewModelFunc)
        {
            var bgScheduler = RxApp.TaskpoolScheduler;
            var mScheduler = RxApp.MainThreadScheduler;
            var vLocator = Locator.Current.GetService<IViewLocator>();

            var navigationView = new Sextant.XamForms.NavigationView(mScheduler, bgScheduler, vLocator);
            var viewStackService = new ViewStackService(navigationView);
            var model = createViewModelFunc(viewStackService);

            navigationView.Title = model.TabTitle;
            navigationView.Icon = model.TabIcon;

            navigationView.PushPage(model as ViewModelBase, null, true, false).Subscribe();
            return navigationView;
        }
    }
}
