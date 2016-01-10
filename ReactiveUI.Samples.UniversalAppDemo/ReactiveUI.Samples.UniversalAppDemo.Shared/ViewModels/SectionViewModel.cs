using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI.Samples.UniversalAppDemo.Data;

namespace ReactiveUI.Samples.UniversalAppDemo.ViewModels
{
    public class SectionViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly SampleDataGroup _sampleDataGroup;
        private SampleDataItem _itemToNavigate;

        public SectionViewModel(IScreen hostScreen, SampleDataGroup sampleDataGroup)
        {
            _sampleDataGroup = sampleDataGroup;
            HostScreen = hostScreen;

            NavigateToItemCommand = ReactiveCommand.Create();

            this.WhenAnyValue(x => x.ItemToNavigate)
                .Where(x => x != null)
                .Subscribe(x => HostScreen.Router.Navigate.Execute(new ItemViewModel(HostScreen, x)));
        }

        public string UrlPathSegment
        {
            get { return "section"; }
        }

        public IScreen HostScreen { get; private set; }

        public SampleDataGroup Group
        {
            get { return _sampleDataGroup; }
        }

        public IEnumerable<SampleDataItem> Items
        {
            get { return _sampleDataGroup.Items; }
        }

        public SampleDataItem ItemToNavigate
        {
            get { return _itemToNavigate; }
            set { this.RaiseAndSetIfChanged(ref _itemToNavigate, value); }
        }

        public ReactiveCommand<object> NavigateToItemCommand { get; private set; }
    }
}