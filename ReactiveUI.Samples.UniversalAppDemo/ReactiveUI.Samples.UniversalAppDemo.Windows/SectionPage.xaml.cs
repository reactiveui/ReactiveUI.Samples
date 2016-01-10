using System;
using System.Reactive.Linq;
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
                .Cast<ItemClickEventArgs>()
                .Select(x => x.ClickedItem)
                .Cast<SampleDataItem>()
                .BindTo(this, x => x.ViewModel.ItemToNavigate);

            this.BindCommand(ViewModel, x => x.HostScreen.Router.NavigateBack, x => x.GoBackButton);
        }
        
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (SectionViewModel)value; }
        }

        public SectionViewModel ViewModel { get; set; }
    }
}