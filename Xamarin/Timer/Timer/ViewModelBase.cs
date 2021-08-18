using System.Reactive.Disposables;
using ReactiveUI;
using Splat;

namespace UI
{
    public abstract class ViewModelBase : ReactiveObject, IEnableLogger
    {
        protected ViewModelBase()
        {
            ComposeObservables();
        }

        public virtual string Id { get; }

        protected CompositeDisposable ViewModelRegistrations { get; } = new CompositeDisposable();

        protected abstract void ComposeObservables();
    }
}
