using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ServerSideExample.ViewModels;

namespace ServerSideExample.Views
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
