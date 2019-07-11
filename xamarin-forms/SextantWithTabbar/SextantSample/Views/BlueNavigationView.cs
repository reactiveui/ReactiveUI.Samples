using System;
using System.Reactive.Concurrency;
using ReactiveUI;
using Sextant;
using Sextant.XamForms;
using Xamarin.Forms;

namespace SextantSample.Views
{
    public class BlueNavigationView : NavigationView, IViewFor
    {
        public BlueNavigationView()
            : base(RxApp.MainThreadScheduler, RxApp.TaskpoolScheduler, ViewLocator.Current)
        {
            this.BarBackgroundColor = Color.Blue;
            this.BarTextColor = Color.White;
        }

        public object ViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
