using System;
using System.Threading;
using System.Windows;

namespace ReactiveUI.Samples.Commands.RxUI
{
    public class MainViewModel : ReactiveObject
    {

        public MainViewModel()
        {
            DisplayCommand = new ReactiveCommand(this.WhenAny(x => x.Name, x => !string.IsNullOrEmpty(x.Value)));
            DisplayCommand.Subscribe(_ => MessageBox.Show("You clicked on DisplayCommand: Name is " + Name));

            StartAsyncCommand = new ReactiveCommand();
            StartAsyncCommand.RegisterAsyncAction(_ =>
            {
                Progress = 0;
                while (Progress <= 100)
                {
                    Progress += 10;
                    Thread.Sleep(100);
                }
            });

        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { this.RaiseAndSetIfChanged(ref _Name, value); }
        }

        public IReactiveCommand DisplayCommand { get; protected set; }

        private int _Progress;

        public int Progress
        {
            get { return _Progress; }
            set { this.RaiseAndSetIfChanged(ref _Progress, value); }
        }

        public ReactiveCommand StartAsyncCommand { get; protected set; }



    }
}