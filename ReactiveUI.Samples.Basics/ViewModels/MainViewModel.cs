using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Reactive;

namespace ReactiveUI.Samples.Basics.ViewModels
{
    public class MainViewModel : ReactiveObject
    {

        public MainViewModel()
        {
            RxApp.DeferredScheduler = new DispatcherScheduler(Application.Current.Dispatcher);
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (Progress == 100)
                    {
                        Progress = 0;

                    }
                    Progress++;
                    Thread.Sleep(Progress%10 == 0 ? 2000 : 400);
                }

            });
            //Throttling the updates for the SlowProgress, Actually we can accomplish it with a few ways
            //@xpaulbettsx is there a better way?
            // 1:
            this.ObservableForProperty(vm => vm.Progress).Throttle(TimeSpan.FromSeconds(1)).Subscribe(
                            Observer.Create<IObservedChange<MainViewModel, int>>(c =>
                {
                    SlowProgress = Progress;

                }));
            // 2:
            this.WhenAny(vm => vm.Progress, model => true).Throttle(TimeSpan.FromSeconds(1), RxApp.DeferredScheduler).Subscribe(
                Observer.Create<bool>(c =>
                {
                    SlowProgress2 = Progress;

                }));

            Person = new PersonViewModel();
            Calculator = new CalculatorViewModel();
        }

        private int _Progress;

        public int Progress
        {
            get { return _Progress; }
            set { this.RaiseAndSetIfChanged(x => x.Progress, value); }
        }

        private int _SlowProgress;

        public int SlowProgress
        {
            get { return _SlowProgress; }
            set { this.RaiseAndSetIfChanged(x => x.SlowProgress, value); }
        }

        private int _SlowProgress2;

        public int SlowProgress2
        {
            get { return _SlowProgress2; }
            set { this.RaiseAndSetIfChanged(x => x.SlowProgress2, value); }
        }

        private PersonViewModel _Person;

        public PersonViewModel Person
        {
            get { return _Person; }
            set { this.RaiseAndSetIfChanged(x => x.Person, value); }
        }

        private CalculatorViewModel _Calculator;

        public CalculatorViewModel Calculator
        {
            get { return _Calculator; }
            set { this.RaiseAndSetIfChanged(x => x.Calculator, value); }
        }

        

         
    }
}