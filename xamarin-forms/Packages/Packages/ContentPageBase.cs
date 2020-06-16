using System.Reactive.Disposables;
using ReactiveUI.XamForms;
using Sextant;

namespace Packages
{
    public abstract class ContentPageBase<T> : ReactiveContentPage<T>, IDestructible
        where T : ViewModelBase
    {
        protected readonly CompositeDisposable ViewBindings = new CompositeDisposable();

        public void Destroy()
        {
            ViewBindings?.Dispose();
        }
    }
}
