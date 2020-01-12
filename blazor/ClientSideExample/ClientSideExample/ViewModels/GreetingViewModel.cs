using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace ClientSideExample.ViewModels
{
    public class GreetingViewModel : ReactiveObject
    {
        private string _name;

        private readonly ObservableAsPropertyHelper<bool> _canClear;
        private readonly ObservableAsPropertyHelper<string> _greeting;

        public ReactiveCommand<Unit, Unit> Clear { get; }

        public bool CanClear => _canClear.Value;
    
        public string Greeting => _greeting.Value;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public GreetingViewModel()
        {
            var canClear = this.WhenAnyValue(x => x.Name)
                .Select(name => !string.IsNullOrEmpty(name));

            Clear = ReactiveCommand.Create(
                () => { Name = string.Empty; },
                canClear);

            _canClear = Clear.CanExecute
                .ToProperty(this, x => x.CanClear);

            _greeting = this.WhenAnyValue(x => x.Name)
                .Select(x => string.IsNullOrWhiteSpace(x) ? string.Empty : $"Hello, {x}!")
                .ToProperty(this, x => x.Greeting);
        }
    }
}
