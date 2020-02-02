using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using HostedExample.Client.ViewModels;



namespace HostedExample.Client.Views
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
