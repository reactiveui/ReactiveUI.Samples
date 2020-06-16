using System.Reactive.Disposables;
using ReactiveUI.XamForms;

namespace Packages
{
    public abstract class ContentViewBase<TViewModel> : ReactiveContentView<TViewModel>
        where TViewModel : ViewModelBase
    {
        protected readonly CompositeDisposable ViewCellBindings = new CompositeDisposable();
    }
}