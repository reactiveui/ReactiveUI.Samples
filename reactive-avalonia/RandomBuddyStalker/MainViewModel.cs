using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;
using System.IO;
using Avalonia.Media.Imaging;
using System.Threading;
using System.Reactive.Disposables;

namespace ReactiveAvalonia.RandomBuddyStalker {
    public class MainViewModel : ReactiveObject, IActivatableViewModel {
        public ViewModelActivator Activator { get; }
        public const int DecisionTimeMilliseconds = 2000;

        public MainViewModel() {
            Activator = new ViewModelActivator();

            IsTimerRunning = false;

            this.WhenActivated(
                disposables => {
                    Disposable
                        // https://stackoverflow.com/a/5838632/12207453
                        .Create(() => BuddyAvatarBitmap?.Dispose())
                        .DisposeWith(disposables);
                });

            var canInitiateNewFetch =
                this.WhenAnyValue(vm => vm.Fetching, fetching => !fetching);

            // https://reactiveui.net/docs/handbook/commands/
            // https://reactiveui.net/docs/handbook/scheduling/
            // https://blog.jonstodle.com/task-toobservable-observable-fromasync-task/
            // https://github.com/reactiveui/ReactiveUI/issues/1245
            StalkCommand =
                ReactiveCommand.CreateFromObservable(
                    () => Observable.StartAsync(Stalk),
                    canInitiateNewFetch,
                    RxApp.MainThreadScheduler
                );

            ContinueCommand =
                ReactiveCommand.CreateFromObservable(
                    () => Observable.StartAsync(Continue),
                    canInitiateNewFetch,
                    RxApp.MainThreadScheduler
                );

            // Run the "Continue" command once in the beginning in order to fetch the first buddy.
            // https://reactiveui.net/docs/handbook/when-activated/#no-need
            ContinueCommand.Execute().Subscribe();

            // https://reactiveui.net/docs/handbook/commands/canceling#canceling-via-another-observable
            var startTimerCommand = ReactiveCommand.CreateFromObservable(
                    () =>
                        Observable
                            .Return(Unit.Default)
                            .Delay(TimeSpan.FromMilliseconds(DecisionTimeMilliseconds))
                            .TakeUntil(
                                TriggeringTheTimer
                                    .Where(trigger => trigger == TimerTrigger.Stop)));

            startTimerCommand.Subscribe(_ => ContinueCommand.Execute().Subscribe());

            this
                .WhenAnyObservable(vm => vm.TriggeringTheTimer)
                .Do(trigger => {
                    if (trigger == TimerTrigger.Start) {
                        startTimerCommand.Execute().Subscribe();
                        IsTimerRunning = true;
                    }
                    else {
                        IsTimerRunning = false;
                    }                    
                })
                .Subscribe();
        }

        // https://github.com/kswoll/ReactiveUI.Fody
        // https://reactiveui.net/docs/handbook/view-models/boilerplate-code#read-write-properties
        [Reactive] public string BuddyName { get; private set; }

        [Reactive] public Bitmap BuddyAvatarBitmap { get; private set; }

        [Reactive] public bool IsTimerRunning { get; private set; }

        [Reactive] private bool Fetching { get; set; }

        // https://reactiveui.net/docs/handbook/commands/
        public ReactiveCommand<Unit, Unit> StalkCommand { get; }

        public ReactiveCommand<Unit, Unit> ContinueCommand { get; }

        // https://rehansaeed.com/reactive-extensions-part1-replacing-events/
        private readonly Subject<TimerTrigger> _triggeringTheTimer = new Subject<TimerTrigger>();
        public IObservable<TimerTrigger> TriggeringTheTimer => _triggeringTheTimer.AsObservable();

        private const int TimeoutLimit = 3000;
        private static readonly TimeSpan _fetchTimeoutSpan =
            TimeSpan.FromMilliseconds(TimeoutLimit);

        private string _userAvatarUrl;

        // https://stackoverflow.com/questions/14455293/how-and-when-to-use-async-and-await
        // https://medium.com/rubrikkgroup/understanding-async-avoiding-deadlocks-e41f8f2c6f5d
        private async Task Stalk() {
            _triggeringTheTimer.OnNext(TimerTrigger.Stop);
            
            Fetching = true;

            // https://rehansaeed.com/reactive-extensions-rx-part-8-timeouts/
            using (var timeoutTokenSource = new CancellationTokenSource(_fetchTimeoutSpan)) {
                try {
                    byte[] bytes = await _userAvatarUrl.GetBytesAsync(timeoutTokenSource.Token);
                    BuddyAvatarBitmap = new Bitmap(new MemoryStream(bytes));
                }
                catch {
                    Console.WriteLine("Could not fetch avatar");
                }
            }

            Fetching = false;
        }

        private static readonly Random _randomizer = new Random();
        
        private async Task Continue() {
            Fetching = true;

            // At the time of writing the sample service provided by reqres.in
            // exposes 12 users with id's in [1..12]
            int userId = _randomizer.Next() % 12 + 1;

            // https://stackoverflow.com/a/5838632/12207453
            BuddyAvatarBitmap?.Dispose();
            BuddyAvatarBitmap = null;

            // https://rehansaeed.com/reactive-extensions-rx-part-8-timeouts/
            using (var timeoutTokenSource = new CancellationTokenSource(_fetchTimeoutSpan)) {
                var userDtoFetcherTask =
                        "https://reqres.in/api/"
                            .AppendPathSegments("users", userId)
                            .GetJsonAsync<UserDto>(timeoutTokenSource.Token);
                try {
                    var user = await userDtoFetcherTask;
                    _userAvatarUrl = user.Data.AvatarUrl;
                    BuddyName = $"{user.Data.FirstName} {user.Data.LastName}";
                }
                catch {
                    Console.WriteLine("Could not fetch buddy info");
                }
            }

            Fetching = false;

            // https://rehansaeed.com/reactive-extensions-part1-replacing-events/
            _triggeringTheTimer.OnNext(TimerTrigger.Start);
        }
    }

    public enum TimerTrigger { 
        Start,
        Stop
    }
}
