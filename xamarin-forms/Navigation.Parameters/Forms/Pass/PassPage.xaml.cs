using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using Xamarin.Forms;

namespace Navigation.Parameters
{
    public partial class PassPage : ContentPageBase<PassViewModel>
    {
        public PassPage()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.PassingParameter, view => view.ParameterEntry.Text)
                .DisposeWith(ControlBindings);

            this.BindCommand(ViewModel, vm => vm.Navigate, view => view.NavigateButton)
                .DisposeWith(ControlBindings);

            this.WhenActivated(deactivated =>
            {
                this.BindValidation(ViewModel, vm => vm.PassingParameter, view => view.ParameterErrorLabel.Text)
                    .DisposeWith(deactivated);
            });
        }
    }
}
