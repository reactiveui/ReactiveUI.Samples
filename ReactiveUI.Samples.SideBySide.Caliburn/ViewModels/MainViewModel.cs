using System;
using System.ComponentModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace ReactiveUI.Samples.SideBySide.CaliburnMicro.ViewModels
{
    /// <summary>
    /// In order to make any ViewModel part of ReactiveUI we need to
    /// 1. Enjoy the Awesomeness of ReactiveUI
    /// That's it, with version 5 of ReactiveUI it Just Works
    /// </summary>
    public class MainViewModel : Screen
    {

        public MainViewModel()
        {
            DisplayName = "Caliburn.Micro works side-by-side with ReactiveUI";

            RxApp.MainThreadScheduler = new DispatcherScheduler(Application.Current.Dispatcher);
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
            
            //Throttling the Progress property updates for the SlowProgress. 
            //Two ways to observe the changes on the Progress property
            // 1:
            this.ObservableForProperty(vm => vm.Progress)
                .Throttle(TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler)
                .Subscribe(c => SlowProgress = Progress);
            // 2:
            this.WhenAny(vm => vm.Progress, model => true)
                .Throttle(TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler).
                Subscribe(c => SlowProgress2 = Progress);

            Person = new PersonViewModel();
            Calculator = new CalculatorViewModel();
        }

        public CalculatorViewModel CalculatorViewModel { get; private set; }


        private int _Progress;
        public int Progress
        {
            get { return _Progress; }
            set
            {
                if (value == _Progress) return;
                _Progress = value;
                NotifyOfPropertyChange(() => Progress);
            }
        }

        private int _SlowProgress;
        public int SlowProgress
        {
            get { return _SlowProgress; }
            set
            {
                if (value==_SlowProgress) return;
                _SlowProgress = value;
                NotifyOfPropertyChange(() => SlowProgress);
            }
        }

        private int _SlowProgress2;
        public int SlowProgress2
        {
            get { return _SlowProgress2; }
            set
            {
                if (value==_SlowProgress2) return;
                _SlowProgress2 = value;
                NotifyOfPropertyChange(() => SlowProgress2);
            }
        }

        private PersonViewModel _Person;
        public PersonViewModel Person
        {
            get { return _Person; }
            set
            {
                if (value == _Person) return;
                _Person = value;
                NotifyOfPropertyChange(() => Person);
            }
        }

        private CalculatorViewModel _Calculator;
        public CalculatorViewModel Calculator
        {
            get { return _Calculator; }
            set
            {
                if (value==_Calculator) return;
                _Calculator = value;
                NotifyOfPropertyChange(() => Calculator);
            }
        }
    }
}