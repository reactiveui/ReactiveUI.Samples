using System;
using ReactiveUI;

using Windows.UI.Xaml.Controls;
using ReactiveUI.Samples.UniversalAppDemo.Data;
using ReactiveUI.Samples.UniversalAppDemo.ViewModels;

namespace ReactiveUI.Samples.UniversalAppDemo
{
    public sealed partial class SectionPage : IViewFor<SectionViewModel>
    {
        public SectionPage()
        {
            InitializeComponent();

            this.WhenAnyValue(x => x.ViewModel)
                .Subscribe(x => DataContext = x);

            this.WhenAnyObservable(x => x.ViewModel.NavigateToItemCommand)
                .Subscribe(x =>
                {
                    var eventPattern = (ItemClickEventArgs)x;

                    var sampleDataItem = (SampleDataItem)eventPattern.ClickedItem;
                    ViewModel.HostScreen.Router.Navigate.Execute(new ItemViewModel(ViewModel.HostScreen, sampleDataItem));
                });

            this.WhenAnyObservable(x => x.ViewModel.GoBackCommand)
                .Subscribe(x => ViewModel.HostScreen.Router.NavigateBack.Execute(null));

        }
        
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (SectionViewModel)value; }
        }

        public SectionViewModel ViewModel { get; set; }
    }
}