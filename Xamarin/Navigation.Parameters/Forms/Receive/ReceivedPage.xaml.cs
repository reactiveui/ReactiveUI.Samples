using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;
using Xamarin.Forms;

namespace Navigation.Parameters
{
    public partial class ReceivedPage : ContentPageBase<ReceivedViewModel>
    {
        public ReceivedPage()
        {
            InitializeComponent();

            // This line throws an error.
            this.OneWayBind(ViewModel, vm => vm.ReceivedParameter, view => view.ReceivedParameter.Text).DisposeWith(ControlBindings);
        }
    }
}
