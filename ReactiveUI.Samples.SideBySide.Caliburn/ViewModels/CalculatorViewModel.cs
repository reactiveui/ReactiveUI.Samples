using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using ReactiveUI.Xaml;

namespace ReactiveUI.Samples.SideBySide.CaliburnMicro.ViewModels
{
    public class CalculatorViewModel : Screen, IReactiveNotifyPropertyChanged
    {
        private MemoizingMRUCache<int, int> _cache;
        private MakeObjectReactiveHelper _reactiveHelper;

        public CalculatorViewModel()
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
            _cache = new MemoizingMRUCache<int, int>((x, ctx) =>
            {
                Thread.Sleep(1000);
                // Pretend this calculation isn’t cheap
                return x*10;
            }, 5);

            CalculateCommand = new ReactiveAsyncCommand(this.WhenAny(x => x.Number, x => x.Value > 0));
            (CalculateCommand as ReactiveAsyncCommand).RegisterAsyncTask<object>(o =>
            {
                return Task.Factory.StartNew(() =>
                {
                    int top;
                    bool cached = _cache.TryGet(    Number, out top);
                    if (cached)
                    {
                        Result = 0;
                        Thread.Sleep(1000);
                        Result = top;
                    }
                    else
                    {
                        top = _cache.Get(Number);
                        for (int i = 0; i <= top; i++)
                        {
                            Result = i;
                            Thread.Sleep(100);
                        }
                    }
                });
            });
        }

        private int _Number;
        public int Number
        {
            get { return _Number; }
            set
            {
                if (_Number == value) return;
                _Number = value;
                NotifyOfPropertyChange(()=>Number);
            }
        }

        public ICommand CalculateCommand { get; set; }

        private int _Result;
        public int Result
        {
            get { return _Result; }
            set
            {
                if (_Result==value) return;
                _Result = value;
                NotifyOfPropertyChange(() => Result);
            }
        }

        public IObservable<IObservedChange<object, object>> Changed
        {
            get { return _reactiveHelper.Changed; }
        }
        public IObservable<IObservedChange<object, object>> Changing
        {
            get { return _reactiveHelper.Changing; }
        }
        public IDisposable SuppressChangeNotifications()
        {
            return _reactiveHelper.SuppressChangeNotifications();
        }
        public event PropertyChangingEventHandler PropertyChanging;
    }
}