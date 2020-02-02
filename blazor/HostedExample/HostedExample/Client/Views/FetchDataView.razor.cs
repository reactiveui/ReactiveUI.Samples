using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using HostedExample.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using ReactiveUI;

namespace HostedExample.Client.Views
{
    public partial class FetchDataView 
    {
        [Inject]
        public FetchDataViewModel FetchViewModel
        {
            get => ViewModel;
            set => ViewModel = value;
            
        }

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.LoadForecasts.Execute().ToTask();
        }
    }
}
