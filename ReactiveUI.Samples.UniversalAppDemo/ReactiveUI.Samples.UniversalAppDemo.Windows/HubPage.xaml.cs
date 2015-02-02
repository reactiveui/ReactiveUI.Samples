using System;
using Windows.UI.Xaml.Controls;
using ReactiveUI.Samples.UniversalAppDemo.Data;
using ReactiveUI.Samples.UniversalAppDemo.ViewModels;

namespace ReactiveUI.Samples.UniversalAppDemo
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class HubPage : IViewFor<HubViewModel>
    {
        public HubPage()
        {
            InitializeComponent();

            this.WhenAnyValue(x => x.ViewModel)
                .Subscribe(x => DataContext = x);

            this.WhenAnyObservable(x => x.ViewModel.NavigateToSectionCommand)
                .Subscribe(x =>
                    {
                        var args = (HubSectionHeaderClickEventArgs)x;

                        var viewModel = (HubViewModel)args.Section.DataContext;
                        ViewModel.HostScreen.Router.Navigate.Execute(new SectionViewModel(ViewModel.HostScreen, viewModel.Groups[2]));
                    });

            this.WhenAnyObservable(x => x.ViewModel.NavigateToItemCommand)
                .Subscribe(x =>
                {
                    var args = (ItemClickEventArgs)x;

                    var sampleDataItem = (SampleDataItem)args.ClickedItem;
                    ViewModel.HostScreen.Router.Navigate.Execute(new ItemViewModel(ViewModel.HostScreen, sampleDataItem));
                });

            this.WhenAnyObservable(x => x.ViewModel.GoBackCommand)
                .Subscribe(x => ViewModel.HostScreen.Router.NavigateBack.Execute(null));
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (HubViewModel)value; }
        }

        public HubViewModel ViewModel { get; set; }
    }
}
