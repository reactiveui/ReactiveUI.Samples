using ReactiveUI;
using ReactiveUI.XamForms;
using Sextant;
using SextantSample.ViewModels;
using System.Reactive.Disposables;

namespace SextantSample.Views
{
	public partial class HomeView : ReactiveContentPage<HomeViewModel>
    {
		public HomeView()
        {
            InitializeComponent();

			this.WhenActivated(disposables =>
            {
				this.BindCommand(ViewModel, x => x.OpenModal, x => x.FirstModalButton).DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.PushPage, x => x.PushPage);
            });
        }
    }
}
