using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ClientSideExample.ViewModels;
using Microsoft.AspNetCore.Components;
using ReactiveUI;


namespace ClientSideExample.Views
{
    public partial class FetchDataView : IViewFor<FetchDataViewModel>
    {
        [Inject]
        public FetchDataViewModel ViewModel { get; set; }


        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FetchDataViewModel)value;
        }

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.LoadForecasts.Execute().ToTask();
        }
    }
}
