using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using AppKit;
using CoreGraphics;
using Foundation;
using ReactiveUI;
using Splat;
using static AppKit.NSApplication;

namespace UI
{
    public partial class ViewController : ViewControllerBase<MainViewModel>
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
            ViewModel = new MainViewModel();
        }

        public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            // Take action based on the segue name
            switch (segue.Identifier)
            {
                case "TimerModalSegue":
                    var dialog = segue.DestinationController as Modal;
                    dialog.Presenter = this;
                    dialog.ViewModel.TimerValue = this.ViewModel.TimerValue;
                    break;
            }
        }
        protected override void ComposeObservables()
        {
            this.WhenAnyObservable(x => x.ViewModel.StartTimerCommand)
                .Do(_ => this.Log().Debug("TimerModalSegue"))
                .Subscribe(_ => PerformSegue("TimerModalSegue", this))
                .DisposeWith(Bindings);
        }

        protected override void BindControls()
        {
            this.WhenAnyValue(x => x.TimeEntryField.StringValue)
                .Throttle(TimeSpan.FromSeconds(.35))
                .Subscribe(x => ViewModel.TimerValue = x)
                .DisposeWith(Bindings);

            this.BindCommand(ViewModel, vm => vm.StartTimerCommand, controller => controller.TimerButton)
                .DisposeWith(Bindings);
        }
    }
}
