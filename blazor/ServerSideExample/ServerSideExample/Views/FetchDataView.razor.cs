using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ReactiveUI;
using ServerSideExample.ViewModels;

namespace ServerSideExample.Views
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

        protected override Task OnInitializedAsync()
        {
            ViewModel.LoadForecasts.Execute().SubscribeOn(RxApp.MainThreadScheduler).Subscribe();
            return Task.CompletedTask;
        }

    }
}
