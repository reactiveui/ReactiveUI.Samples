using System;
using HostedExample.Client.ViewModels;
using ReactiveUI;
using ReactiveUI.Blazor;

namespace HostedExample.Client.Views
{
    public partial class GreetingView : IViewFor<GreetingViewModel>
    {
        public GreetingView()
        {
            ViewModel = new GreetingViewModel();
        }

        public GreetingViewModel ViewModel { get; set; }
        object IViewFor.ViewModel 
        {
            get => ViewModel;
            set => ViewModel = (GreetingViewModel)value;
        }

        public void Clear()
        {
            ViewModel.Clear.Execute().Subscribe();
        }
    }
}
