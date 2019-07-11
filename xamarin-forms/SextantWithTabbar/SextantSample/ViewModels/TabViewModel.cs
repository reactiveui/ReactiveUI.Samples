using System;
using ReactiveUI;
using Sextant;
using Xamarin.Forms;
using System.Reactive.Disposables;


namespace SextantSample.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        public string TabTitle { get; }
        public FileImageSource TabIcon { get; }
        public TabViewModel(string tabTitle, string tabIcon, IViewStackService viewStackService, Func<IPageViewModel> pageCreate) : base(viewStackService)
        {
            TabIcon = tabIcon;
            TabTitle = tabTitle;

            this.WhenActivated(disposable =>
            {
                viewStackService.PushPage(pageCreate(), resetStack: true).Subscribe().DisposeWith(disposable);
            });
        }
    }
}
