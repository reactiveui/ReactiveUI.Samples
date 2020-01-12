using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ReactiveUI;
using ServerSideExample.ViewModels;

namespace ServerSideExample.Views
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

        private async Task IncrementCount()
        {
            await ViewModel.Increment.Execute().ToTask();
        }
    }
}
