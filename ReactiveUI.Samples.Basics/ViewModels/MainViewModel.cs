using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ReactiveUI.Samples.Basics.ViewModels
{
    public class MainViewModel : ReactiveObject
    {

        public MainViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (Progress == 100)
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Progress = 0;
                        }));

                    }
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Progress++;
                    }));
                    
                    Thread.Sleep(400);
                }

            });
        }

        private int _Progress;

        public int Progress
        {
            get { return _Progress; }
            set { this.RaiseAndSetIfChanged(x => x.Progress, value); }
        }
         
    }
}