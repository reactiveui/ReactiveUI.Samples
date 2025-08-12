using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ClientSideExample.ViewModels;

namespace ClientSideExample.Views;

public partial class GreetingView
{
    public GreetingView()
    {
        ViewModel = new GreetingViewModel();
    }

    public async Task Clear()
    {
        await ViewModel.Clear.Execute().ToTask();
    }
}