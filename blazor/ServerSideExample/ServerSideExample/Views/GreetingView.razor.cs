using System;
using ReactiveUI;
using ServerSideExample.ViewModels;

namespace ServerSideExample.Views
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
