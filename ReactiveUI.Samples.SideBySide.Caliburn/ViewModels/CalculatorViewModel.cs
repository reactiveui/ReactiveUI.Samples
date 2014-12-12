using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using ReactiveUI;
using Splat;
using System.Reactive;

namespace ReactiveUI.Samples.SideBySide.CaliburnMicro.ViewModels
{
    public class CalculatorViewModel : Screen
    {
        private MemoizingMRUCache<int, int> _cache;

        public CalculatorViewModel()
        {
            _cache = new MemoizingMRUCache<int, int>((x, ctx) =>
            {
                Thread.Sleep(1000);
                // Pretend this calculation isn’t cheap
                return x*10;
            }, 5);


             CalculateCommand = 
                ReactiveCommand.CreateAsyncTask<object>(
                    this.WhenAnyValue(x => x.Number, x => x > 0),
                    o =>
                    {
                        return Task<object>.Factory.StartNew(() =>
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

                            return null;
                        });
                    },
                    RxApp.MainThreadScheduler);

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

        public IReactiveCommand<object> CalculateCommand { get; set; }

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
    }
}