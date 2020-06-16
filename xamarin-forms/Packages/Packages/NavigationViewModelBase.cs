using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Sextant;

namespace Packages
{
    public abstract class NavigationViewModelBase : ViewModelBase, INavigable
    {
        public string Id { get; }

        public virtual IObservable<Unit> WhenNavigatedTo(INavigationParameter parameter)
        {
            return Observable.Create<Unit>(_ => Disposable.Empty);
        }

        public virtual IObservable<Unit> WhenNavigatedFrom(INavigationParameter parameter)
        {
            return Observable.Create<Unit>(_ => Disposable.Empty);
        }

        public virtual IObservable<Unit> WhenNavigatingTo(INavigationParameter parameter)
        {
            return Observable.Create<Unit>(_ => Disposable.Empty);
        }
    }
}
