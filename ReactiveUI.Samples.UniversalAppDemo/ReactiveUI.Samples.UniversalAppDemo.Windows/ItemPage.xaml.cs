using System;
using ReactiveUI.Samples.UniversalAppDemo.ViewModels;

namespace ReactiveUI.Samples.UniversalAppDemo
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class ItemPage : IViewFor<ItemViewModel>
    {
        public ItemPage()
        {
            InitializeComponent();

            this.WhenAnyValue(x => x.ViewModel)
                .Subscribe(x => DataContext = x);

            this.BindCommand(ViewModel, x => x.HostScreen.Router.NavigateBack, x => x.GoBackButton);
        }
        
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ItemViewModel)value; }
        }

        public ItemViewModel ViewModel { get; set; }
    }
}