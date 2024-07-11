using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ClientSideExample.ViewModels;

namespace ClientSideExample.Views;

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