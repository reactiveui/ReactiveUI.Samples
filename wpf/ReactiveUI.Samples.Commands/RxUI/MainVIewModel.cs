using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ReactiveUI.Samples.Commands.RxUI
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            DisplayCommand = ReactiveCommand.Create(() => this.WhenAny(x => x.Name, x => !string.IsNullOrEmpty(x.Value)));
            DisplayCommand.Subscribe(_ => MessageBox.Show("You clicked on DisplayCommand: Name is " + Name));

            StartAsyncCommand = ReactiveCommand.CreateFromTask(() =>
            {
                return Task.Run(() =>
                {
                    Progress = 0;
                    while (Progress <= 100)
                    {
                        Progress += 10;
                        Thread.Sleep(100);
                    }

                    return AsyncVoid.Default;
                });
            });
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { this.RaiseAndSetIfChanged(ref _Name, value); }
        }

        public ReactiveCommand<Unit, IObservable<bool>> DisplayCommand { get; protected set; }

        private int _Progress;

        public int Progress
        {
            get { return _Progress; }
            set { this.RaiseAndSetIfChanged(ref _Progress, value); }
        }

        public ReactiveCommand<Unit, AsyncVoid> StartAsyncCommand { get; protected set; }
    }
}
