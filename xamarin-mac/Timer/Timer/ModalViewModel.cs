using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Foundation;
using ReactiveUI;
using Splat;

namespace UI
{
    /// <summary>
    /// Timer modal view model.
    /// </summary>
    /// <seealso cref="UI.ViewModelBase" />
    public class ModalViewModel : ViewModelBase
    {
        private ObservableAsPropertyHelper<TimeSpan> _timer;
        private string _timerValue;
        private string _buttonText;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalViewModel"/> class.
        /// </summary>
        public ModalViewModel()
        {
            ButtonText = nameof(Dismiss);
        }

        /// <inheritdoc/>
        public override string Id => "Timer";

        /// <summary>
        /// Gets or sets the timer value.
        /// </summary>
        public string TimerValue
        {
            get => _timerValue;
            set => this.RaiseAndSetIfChanged(ref _timerValue, value);
        }

        /// <summary>
        /// Gets or sets the button text.
        /// </summary>
        public string ButtonText
        {
            get => _buttonText;
            set => this.RaiseAndSetIfChanged(ref _buttonText, value);
        }

        /// <summary>
        /// Gets the timer.
        /// </summary>
        public TimeSpan Timer => _timer.Value;

        /// <summary>
        /// Gets the dismiss.
        /// </summary>
        public ReactiveCommand<Unit, Unit> Dismiss { get; private set; }

        /// <inheritdoc/>
        protected override void ComposeObservables()
        {
            var timerObservable = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(x => TimeSpan.FromMinutes(Convert.ToDouble(TimerValue)) - TimeSpan.FromSeconds(x))
                .TakeUntil(x => x.Ticks == 0);

            _timer =
                timerObservable
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .ToProperty(this, x => x.Timer, TimeSpan.FromMinutes(Convert.ToDouble(TimerValue)))
                    .DisposeWith(ViewModelRegistrations);

            timerObservable
                .Where(x => x.Ticks == 0)
                .Do(_ => this.Log().Debug("Ticks are Zero"))
                .Subscribe(_ =>
                {
                    var notification = new NSUserNotification
                    {
                        Title = $"{TimerValue} minute(s) is up!",
                        InformativeText = "Blast off!!!",
                        DeliveryDate = (NSDate)DateTime.Now,
                        SoundName = NSUserNotification.NSUserNotificationDefaultSoundName,
                        HasActionButton = true
                    };

                    // Make sure the notification fires even if the app is TopMost
                    NSUserNotificationCenter.DefaultUserNotificationCenter.ShouldPresentNotification = (c, n) => true;

                    NSUserNotificationCenter.DefaultUserNotificationCenter.ScheduleNotification(notification);

                    Dismiss.Execute().Subscribe();
                })
                .DisposeWith(ViewModelRegistrations);

            Dismiss = ReactiveCommand.Create(() => this.Log().Debug(nameof(Dismiss)))
                .DisposeWith(ViewModelRegistrations);
        }
    }
}
