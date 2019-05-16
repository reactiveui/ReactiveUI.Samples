using System;
using System.Reactive.Linq;
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
                .Cast<HubSectionHeaderClickEventArgs>()
                .Select(x => x.Section.DataContext)
                .Cast<HubViewModel>()
                .Select(x => x.Groups[2])
                .BindTo(this, x => x.ViewModel.GroupToNavigate);

            this.WhenAnyObservable(x => x.ViewModel.NavigateToItemCommand)
                .Cast<ItemClickEventArgs>()
                .Select(x => x.ClickedItem)
                .Cast<SampleDataItem>()
                .BindTo(this, x => x.ViewModel.ItemToNavigate);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (HubViewModel)value; }
        }

        public HubViewModel ViewModel { get; set; }
    }
}
