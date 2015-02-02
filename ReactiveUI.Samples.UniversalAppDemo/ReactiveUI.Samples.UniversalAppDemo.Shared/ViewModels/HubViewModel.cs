using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI.Samples.UniversalAppDemo.Data;

namespace ReactiveUI.Samples.UniversalAppDemo.ViewModels
{
    public class HubViewModel : ReactiveObject, IRoutableViewModel
    {
        private SampleDataGroup _groupToNavigate;
        private SampleDataItem _itemToNavigate;

        public HubViewModel(IScreen screen)
        {
            HostScreen = screen;
            NavigateToSectionCommand = ReactiveCommand.Create();
            NavigateToItemCommand = ReactiveCommand.Create();
            GoBackCommand = ReactiveCommand.Create();

            this.WhenAnyValue(x => x.GroupToNavigate)
                .Where(x => x != null)
                .Subscribe(x => HostScreen.Router.Navigate.Execute(new SectionViewModel(HostScreen, x)));

            this.WhenAnyValue(x => x.ItemToNavigate)
                .Where(x => x != null)
                .Subscribe(x => HostScreen.Router.Navigate.Execute(new ItemViewModel(HostScreen, x)));

            this.WhenNavigatedTo(() =>
                {
                    SetGroups();
                    return Disposable.Empty;
                });
        }

        public ReactiveCommand<object> NavigateToSectionCommand { get; private set; }
        public ReactiveCommand<object> NavigateToItemCommand { get; private set; }
        public ReactiveCommand<object> GoBackCommand { get; private set; }

        public SampleDataGroup[] Groups { get; private set; }

        public SampleDataGroup GroupToNavigate 
        {
            get { return _groupToNavigate; }
            set { this.RaiseAndSetIfChanged(ref _groupToNavigate, value); }
        }

        public SampleDataItem ItemToNavigate
        {
            get { return _itemToNavigate; }
            set { this.RaiseAndSetIfChanged(ref _itemToNavigate, value); }
        }
        
        public IScreen HostScreen { get; private set; }

        public string UrlPathSegment
        {
            get { return "hubpage"; }
        }

        private async void SetGroups()
        {
            Groups = await SampleDataSource.GetGroupsAsync();
        }
    }
}