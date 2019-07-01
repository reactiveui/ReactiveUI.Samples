using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Windows.Input;
using System.Reactive.Linq;
using System.Reactive;
using ReactiveUI;
using Splat;

namespace ReactiveUI.Samples.Suspension.ViewModels
{
    [DataContract]
    public class SearchViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly ReactiveCommand<Unit, Unit> _search;
        private string _searchQuery;

        public SearchViewModel(IScreen screen = null) 
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            
            var canSearch = this
                .WhenAnyValue(x => x.SearchQuery)
                .Select(query => !string.IsNullOrWhiteSpace(query));
            
            _search = ReactiveCommand.CreateFromTask(
                () => Task.Delay(1000),
                canSearch);
        }

        public IScreen HostScreen { get; }

        public string UrlPathSegment => "/search";

        public ICommand Search => _search;
        
        [DataMember]
        public string SearchQuery 
        {
            get => _searchQuery;
            set => this.RaiseAndSetIfChanged(ref _searchQuery, value);
        }
    }
}