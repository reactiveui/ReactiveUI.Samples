using System;
using Microsoft.AspNetCore.Components;
using ReactiveUI.RazorExample.ViewModels;

namespace ReactiveUI.RazorExample.Views
{
    public partial class GreetingView : ComponentBase, IViewFor<GreetingViewModel>
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
