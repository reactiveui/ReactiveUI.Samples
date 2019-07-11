using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using Sextant;
using SextantSample.ViewModels;

namespace SextantSample.Views
{
	public partial class RedView : ReactiveContentPage<RedViewModel>
    {
        public RedView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.BindCommand(ViewModel, x => x.PopModal, x => x.PopModal).DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.PushPage, x => x.PushPage).DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.PopPage, x => x.PopPage).DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.PopToRoot, x => x.PopToRoot).DisposeWith(disposable);
            });
        }
    }
}
