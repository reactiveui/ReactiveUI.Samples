using System;
using ClientSideExample.ViewModels;
using ReactiveUI;

namespace ClientSideExample.Views
{
    public partial class CounterView : IViewFor<CounterViewModel>
    {
        public CounterView()
        {
            ViewModel = new CounterViewModel();
        }

        public CounterViewModel ViewModel { get; set; }
        object IViewFor.ViewModel 
        {
            get => ViewModel;
            set => ViewModel = (CounterViewModel)value;
        }

        private void IncrementCount()
        {
            ViewModel.Increment.Execute().Subscribe();
        }
    }
}
