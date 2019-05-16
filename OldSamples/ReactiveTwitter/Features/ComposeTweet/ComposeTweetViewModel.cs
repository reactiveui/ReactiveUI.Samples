using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Genesis.Ensure;
using ReactiveUI;

namespace Features.ComposeTweet
{
    public class ComposeTweetViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<int> _charactersRemaining;
        private readonly IScheduler _scheduler;
        private string _message;

        public ComposeTweetViewModel(IScheduler scheduler)
        {
            Ensure.ArgumentNotNull(scheduler, nameof(scheduler));

            _scheduler = scheduler;

            _charactersRemaining = this
                .WhenAnyValue(vm => vm.Message)
                .Select(message => message?.Length ?? 0)
                .Select(length => 240 - length)
                .ToProperty(this, vm => vm.CharactersRemaining);

            var canSend = this.WhenAnyValue(vm => vm.Message, vm => vm._charactersRemaining.Value, (message, charactersRemaining) => !string.IsNullOrWhiteSpace(message) && charactersRemaining >= 0);

            Send = ReactiveCommand.Create(() => { }, canSend, _scheduler);
            Send.Subscribe();
            Send.ThrownExceptions.Subscribe();

            var canCancel = Observable.Return(true);
            Cancel = ReactiveCommand.Create(() => { }, canCancel, _scheduler);
            Cancel.ThrownExceptions.Subscribe();
        }

        public ReactiveCommand<Unit, Unit> Cancel { get; set; }
        public int CharactersRemaining => _charactersRemaining.Value;

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public ReactiveCommand<Unit, Unit> Send { get; set; }
    }
}
