using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace ServerSideExample.ViewModels
{
    public class CounterViewModel : ReactiveObject
    {
        private int _currentCount;

        public CounterViewModel()
        {
            Increment = ReactiveCommand.CreateFromTask(IncrementCount);
        }

        public int CurrentCount
        {
            get => _currentCount;
            set => this.RaiseAndSetIfChanged(ref _currentCount, value);
        }
        
        public ReactiveCommand<Unit, Unit> Increment { get; }

        private Task IncrementCount()
        {
            _currentCount++;
            return Task.FromResult(_currentCount);
        }
    }
}
