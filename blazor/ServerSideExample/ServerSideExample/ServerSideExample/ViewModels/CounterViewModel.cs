using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ServerSideExample.ViewModels
{
    public class CounterViewModel : ReactiveObject
    {
        private int currentCount;

        public CounterViewModel()
        {
            Increment = ReactiveCommand.CreateFromTask(IncrementCount);
        }

        public int CurrentCount => currentCount;
        

        public ReactiveCommand<Unit, Unit> Increment;

        private Task IncrementCount()
        {
            currentCount++;
            return Task.CompletedTask;
        }
    }
}
