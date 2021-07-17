using System.Reactive;
using ReactiveUI;
using Splat;

namespace UI
{
    public class MainViewModel : ViewModelBase
    {
        private string _timerValue;

        public string TimerValue
        {
            get => _timerValue;
            set => this.RaiseAndSetIfChanged(ref _timerValue, value);
        }

        public ReactiveCommand<Unit, Unit> StartTimerCommand { get; private set; }

        protected override void ComposeObservables()
        {
            StartTimerCommand = ReactiveCommand.Create(() =>
            {
                this.Log().Debug($"Execute {nameof(StartTimerCommand)}");
            });
        }
    }
}