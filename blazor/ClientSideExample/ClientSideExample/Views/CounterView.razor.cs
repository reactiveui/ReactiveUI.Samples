using System.Reactive.Linq;
using System.Threading.Tasks;
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

        private async Task IncrementCount()
        {
            await ViewModel.Increment.Execute().SubscribeOn(RxApp.MainThreadScheduler);
        }
    }
}
