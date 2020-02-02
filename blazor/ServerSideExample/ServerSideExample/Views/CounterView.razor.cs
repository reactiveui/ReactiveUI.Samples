using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ServerSideExample.ViewModels;

namespace ServerSideExample.Views
{
    public partial class CounterView
    {
        public CounterView()
        {
            ViewModel = new CounterViewModel();
        }

        private async Task IncrementCount()
        {
            await ViewModel.Increment.Execute().ToTask();
        }
    }
}
