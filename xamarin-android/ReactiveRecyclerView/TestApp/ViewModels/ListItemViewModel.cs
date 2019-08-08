using ReactiveUI;
using TestApp.DataModels;

namespace TestApp
{
    public class ListItemViewModel : ReactiveObject
    {

        private string _fullName;
        private bool _isSelected;
        
        public ListItemViewModel(ListItemDataModel model)
        {
            FullName = model.Name;
            Group = model.Group;
        }

        public string FullName
        {
            get => _fullName;
            private set => this.RaiseAndSetIfChanged(ref _fullName, value);
        }

        public int Group { get; }

        public bool IsSelected
        {
            get => _isSelected;
            set => this.RaiseAndSetIfChanged(ref _isSelected, value);
        }
    }
}