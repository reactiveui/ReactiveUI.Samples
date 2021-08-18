using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using AppKit;
using Foundation;
using ReactiveUI;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace UI
{
    public abstract class ViewControllerBase<T> : ReactiveViewController<T>
        where T : class
    {
        protected CompositeDisposable Bindings { get; } = new CompositeDisposable();

        protected ViewControllerBase(IntPtr intPtr)
            : base(intPtr)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BindControls();
            ComposeObservables();
        }

        protected abstract void ComposeObservables();

        protected abstract void BindControls();
    }

    public abstract class ViewBase<T> : ReactiveView<T>
        where T : class, IReactiveObject
    {
        protected CompositeDisposable Bindings { get; } = new CompositeDisposable();

        protected ViewBase(IntPtr intPtr)
            : base(intPtr)
        {
        }

        protected abstract void BindControls();
    }
}
