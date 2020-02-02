using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ClientSideExample.ViewModels;
using Microsoft.AspNetCore.Components;


namespace ClientSideExample.Views
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
