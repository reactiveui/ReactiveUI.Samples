using Splat;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReactiveUI.Samples.Basics.ViewModels
{
    public class CalculatorViewModel : ReactiveValidatedObject
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
            

            CalculateCommand = new ReactiveCommand();
            (CalculateCommand as ReactiveCommand).RegisterAsyncTask(o => {
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

        [Required]
        public int Number
        {
            get { return _Number; }
            set { this.RaiseAndSetIfChanged(ref _Number, value); }
        }

        public ICommand CalculateCommand { get; set; }

        private int _Result;

        public int Result
        {
            get { return _Result; }
            set { this.RaiseAndSetIfChanged(ref _Result, value); }
        }
    }
}