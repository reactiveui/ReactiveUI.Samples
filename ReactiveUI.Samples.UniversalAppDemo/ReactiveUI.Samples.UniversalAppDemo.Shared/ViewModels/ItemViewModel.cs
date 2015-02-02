using ReactiveUI.Samples.UniversalAppDemo.Data;

namespace ReactiveUI.Samples.UniversalAppDemo.ViewModels
{
    public class ItemViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly SampleDataItem _sampleDataItem;

        public ItemViewModel(IScreen hostScreen, SampleDataItem sampleDataItem)
        {
            HostScreen = hostScreen;
            _sampleDataItem = sampleDataItem;

            this.WhenNavigatedTo(() =>
                {
                    SetItem();
                    return null;
                });
        }

        public string UrlPathSegment
        {
            get { return "item"; }
        }

        public IScreen HostScreen { get; private set; }

        public SampleDataItem Item { get; private set; }

        private async void SetItem()
        {
            Item = await SampleDataSource.GetItemAsync(_sampleDataItem.UniqueId);
        }
    }
} 