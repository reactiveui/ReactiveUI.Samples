using System;
using System.Reactive.Disposables;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace Navigation.Parameters
{
    public abstract class ContentPageBase<T> : ReactiveContentPage<T>
        where T : ViewModelBase
    {
        protected CompositeDisposable ControlBindings { get; } = new CompositeDisposable();
    }
}

