using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using HostedExample.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using ReactiveUI;

namespace HostedExample.Client.Views
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
